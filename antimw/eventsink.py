from multiprocessing import Process, Queue
from Queue import Empty

from ipcannouncer import IPCAnnouncer

from google.protobuf import timestamp_pb2

import antimw_pb2

import time
import calendar
import pprint
import datetime

class Processor(object):
    def __init__(self, name):
        self.name = name

    def process(self, event, ipcAnnouncer):
        pass

class ConsolePrintProcessor(Processor):
    def __init__(self):
        super(ConsolePrintProcessor, self).__init__('Console Print Processor')

    def process(self, event, ipcAnnouncer):
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

class ThreatProcessor(Processor):
    def __init__(self):
        super(ThreatProcessor, self).__init__('Threat Processor')

    def process(self, event, ipcAnnouncer):
        messageDto = antimw_pb2.MessageDto()

        if event.evType == 'THREAT_FOUND':
            messageDto.threatEventDto.timestamp.FromDatetime(event.datetime)
            messageDto.threatEventDto.threatPath = event.threat.path
            messageDto.threatEventDto.threatName = event.threat.name

        elif event.evType == 'THREATS_FOUND':
            messageDto.threatLogEventDto.timestamp.FromDatetime(event.datetime)
            for threat in event.threats:
                threatDto = messageDto.threatLogEventDto.threatEventDtos.add()
                threatDto.threatPath = threat.path
                threatDto.threatName = threat.name

        ipcAnnouncer.announce(messageDto.SerializeToString())

class LogEventProcessor(Processor):
    def __init__(self):
        super(LogEventProcessor, self).__init__('Log Event Processor')

    def process(self, event, ipcAnnouncer):
        messageDto = antimw_pb2.MessageDto()
        if event.evType == 'ONDEMAND_START':
            messageDto.logEventDto.timestamp.FromDatetime(event.datetime)
            messageDto.logEventDto.eventType = event.evType
        elif event.evType == 'ONDEMAND_FINISH':
            pprint.pprint(event)
            messageDto.logEventDto.timestamp.FromDatetime(event.datetime)
            messageDto.logEventDto.eventType = event.evType
        elif event.evType == 'ONDEMAND_STOP':
            messageDto.logEventDto.timestamp.FromDatetime(event.datetime)
            messageDto.logEventDto.eventType = event.evType
            messageDto.logEventDto.additionalText = event.reason

        ipcAnnouncer.announce(messageDto.SerializeToString())

class EventSink(Process):
    def __init__(self, eventQueue):
        super(EventSink, self).__init__()

        self.commandQueue = Queue()

        self.processors = [ConsolePrintProcessor(), ThreatProcessor(), LogEventProcessor()]
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
                            processor.process(event, ipcAnnouncer)
                        except Exception, e:
                            # Can add an event queue so we don't lose them...
                            print 'Processing failed on ' + processor.name
            except Empty:
                pass

            time.sleep(1)

        ipcAnnouncer.cleanup()

    def cleanup(self):
        self.commandQueue.put('STOP')