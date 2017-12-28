from multiprocessing import Process, Queue
from Queue import Empty

from ipcannouncer import IPCAnnouncer

import time

class Processor(object):
    def __init__(self, name):
        self.name = name

    def process(self, event):
        pass

class ConsolePrintProcessor(Processor):
    def __init__(self):
        super(ConsolePrintProcessor, self).__init__('Console Print Processor')

    def process(self, event):
        eventPrettyDate = event.datetime.strftime('%d-%m-%Y %H:%M:%S')
        eventPrettyPrint = '[' + eventPrettyDate + '][' + event.evType + '] '

        if event.evType == 'THREAT_FOUND':
            print eventPrettyPrint + event.threat.path + ' | ' + event.threat.name
        elif event.evType == 'THREATS_FOUND':
            print eventPrettyPrint

            for threat in event.threats:
                print threat.path + ' | ' + threat.name
        elif event.evType == 'ONDEMAND_START':
            print eventPrettyPrint
        elif event.evType == 'ONDEMAND_STOP':
            print eventPrettyPrint + event.reason
        elif event.evType == 'ONDEMAND_FINISH':
            print eventPrettyPrint
            
class EventSink(Process):
    def __init__(self, eventQueue):
        super(EventSink, self).__init__()

        self.commandQueue = Queue()

        self.processors = [ConsolePrintProcessor()]
        self.eventQueue = eventQueue

    def run(self):
        ipcAnnouncer = IPCAnnouncer()

        while True:
            try:
                command = self.commandQueue.get_nowait()
                if command is not None:
                    if command == 'STOP':
                        break
            except Empty:
                pass

            try:
                event = self.eventQueue.get_nowait()
                if event is not None:
                    for processor in self.processors:
                        try:
                            processor.process(event)
                        except:
                            # Can add an event queue so we don't lose them...
                            print 'Processing failed on ' + processor.name
                            pass
            except Empty:
                pass

            time.sleep(1)

        ipcAnnouncer.cleanup()

    def cleanup(self):
        self.commandQueue.put('STOP')