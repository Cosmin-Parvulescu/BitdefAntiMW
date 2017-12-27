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

        self.eventQueue.put(OnDemandStartEvent(datetime.datetime.utcnow()))

        stopped = False

        while time.time() < loopEndTime:
            try:
                command = self.commandQueue.get_nowait()
                if command is not None:
                    if command == 'STOP':
                        stopped = True
                        self.eventQueue.put(OnDemandStopEvent(datetime.datetime.utcnow(), 'FORCE'))
                        break
            except Empty:
                pass

            if bool(random.getrandbits(1)):
                threat = Threat('C:\\honeypot\\' + str(uuid.uuid4()) + '.pdf', 'OS.Threat')
                threats.append(threat)

            time.sleep(1)

        if stopped is False:
            self.eventQueue.put(OnDemandFinishEvent(datetime.datetime.utcnow()))

        threatsEvent = ThreatLogEvent(threats)
        self.eventQueue.put(threatsEvent)

class RealtimeProcess(Process):
    def __init__(self, commandQueue, eventQueue, **kwargs):
        super(RealtimeProcess, self).__init__()

        self.commandQueue = commandQueue
        self.eventQueue = eventQueue

    def run(self):
        while True:
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

    def start_realtime(self):
        self.realtimeProc = RealtimeProcess(self.realtimeCommandQueue, self.eventQueue)
        self.realtimeProc.start()

    def stop_realtime(self):
        self.realtimeProc.terminate()

    def start_ondemand(self):
        self.ondemandProc = OnDemandProcess(self.ondemandCommandQueue, self.eventQueue)
        self.ondemandProc.start()

    def stop_ondemand(self):
        self.ondemandCommandQueue.put('STOP')