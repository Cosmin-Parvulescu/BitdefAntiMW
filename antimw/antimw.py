from multiprocessing import Process, Queue
from Queue import Empty

import time
import random
import uuid

class OnDemandProcess(Process):
    def __init__(self, commandQueue, eventQueue, **kwargs):
        super(OnDemandProcess, self).__init__()

        self.commandQueue = commandQueue
        self.eventQueue = eventQueue

    def run(self):
        runningTime = random.randint(10, 30)
        loopEndTime = time.time() + runningTime

        while time.time() < loopEndTime:
            try:
                command = self.commandQueue.get_nowait()
                if command is not None:
                    if command == 'STOP':
                        break
            except Empty:
                pass

            if bool(random.getrandbits(1)):
                self.eventQueue.put('C:\\honeypot\\' + str(uuid.uuid4()) + '.pdf|' + 'OS.Threat')

            time.sleep(1)

class RealtimeProcess(Process):
    def __init__(self, commandQueue, eventQueue, **kwargs):
        super(RealtimeProcess, self).__init__()

        self.commandQueue = commandQueue
        self.eventQueue = eventQueue

    def run(self):
        while True:
            if bool(random.getrandbits(1)):
                self.eventQueue.put('C:\\honeypot\\' + str(uuid.uuid4()) + '.pdf|' + 'OS.Threat')

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