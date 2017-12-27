from multiprocessing import Process, Queue
from Queue import Empty

from threat import Threat
from events import ThreatEvent, ThreatLogEvent, OnDemandStopEvent, OnDemandStartEvent, OnDemandFinishEvent

import time
import random
import uuid
import datetime

class OnDemandProcess(Process):
    def __init__(self, commandQueue, eventQueue, **kwargs):
        super(OnDemandProcess, self).__init__()

        self.commandQueue = commandQueue
        self.eventQueue = eventQueue

    def run(self):
        runningTime = random.randint(10, 30)
        startTime = time.time()

        loopEndTime = startTime + runningTime

        threats = []

        self.eventQueue.put(OnDemandStartEvent())

        stopped = False

        while time.time() < loopEndTime:
            try:
                command = self.commandQueue.get_nowait()
                if command is not None:
                    if command == 'STOP':
                        stopped = True
                        self.eventQueue.put(OnDemandStopEvent('FORCE'))
                        break
            except Empty:
                pass

            if bool(random.getrandbits(1)):
                threat = Threat('C:\\honeypot\\' + str(uuid.uuid4()) + '.pdf', 'OS.Threat')
                threats.append(threat)

            time.sleep(1)

        if stopped is False:
            self.eventQueue.put(OnDemandFinishEvent())

        threatsEvent = ThreatLogEvent(threats)
        self.eventQueue.put(threatsEvent)

class RealtimeProcess(Process):
    def __init__(self, commandQueue, eventQueue, **kwargs):
        super(RealtimeProcess, self).__init__()

        self.commandQueue = commandQueue
        self.eventQueue = eventQueue

    def run(self):
        while True:
            try:
                command = self.commandQueue.get_nowait()
                if command is not None:
                    if command == 'STOP':
                        break
            except Empty:
                pass

            if bool(random.getrandbits(1)):
                threat = Threat('C:\\honeypot\\' + str(uuid.uuid4()) + '.pdf', 'OS.Threat')
                threatEvent = ThreatEvent(threat)

                self.eventQueue.put(threatEvent)

            time.sleep(1)

class AntiMW():
    def __init__(self, ondemandCommandQueue, realtimeCommandQueue, eventQueue):
        self.ondemandCommandQueue = ondemandCommandQueue
        self.realtimeCommandQueue = realtimeCommandQueue
        self.eventQueue = eventQueue

        self.ondemandProc = None
        self.realtimeProc = None

    def __isRealtime(self):
        if self.realtimeProc is not None:
            return self.realtimeProc.is_alive()

        return False;

    def __isOndemand(self):
        if self.ondemandProc is not None:
            return self.ondemandProc.is_alive()

        return False;

    def start_realtime(self):
        if self.__isRealtime() is True:
            return -1

        self.realtime = True
            
        self.realtimeProc = RealtimeProcess(self.realtimeCommandQueue, self.eventQueue)
        self.realtimeProc.start()

        return 1

    def stop_realtime(self):
        if self.__isRealtime() is False:
            return -1

        self.realtimeCommandQueue.put('STOP')
        self.realtimeProc.join()

        return 1

    def start_ondemand(self):
        if self.__isOndemand() is True:
            return -1

        self.ondemandProc = OnDemandProcess(self.ondemandCommandQueue, self.eventQueue)
        self.ondemandProc.start()

        return 1

    def stop_ondemand(self):
        if self.__isOndemand() is False:
            return -1

        self.ondemandCommandQueue.put('STOP')
        self.ondemandProc.join()

        return 1

    def cleanup(self):
        if self.__isOndemand() is True:
            self.ondemandCommandQueue.put('STOP')
            self.ondemandProc.join()
        
        if self.__isRealtime() is True:
            self.realtimeCommandQueue.put('STOP')
            self.realtimeProc.join()