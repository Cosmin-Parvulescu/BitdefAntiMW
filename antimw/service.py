from multiprocessing import Queue, Process
from Queue import Empty
from antimw import AntiMW

import time
import datetime

def printer(eventQueue):
    while True:
        event = eventQueue.get()
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
        else:
            print 'NO HANDLER FOR ' + event.evType

def main():
    # There's a bug with strftime, it's not thread safe... https://bugs.python.org/issue7980
    # Apparently it becomes so if you use it before calling any threads, so I'm using this chance to do just that...
    print 'Starting service ' + datetime.datetime.utcnow().strftime('%d-%m-%Y %H:%M:%S')

    eventQueue = Queue()

    realtimeCommandQueue = Queue()
    ondemandCommandQueue = Queue()

    printp = Process(target = printer, args = (eventQueue, ))
    printp.start()

    antiMW = AntiMW(ondemandCommandQueue, realtimeCommandQueue, eventQueue)

    antiMW.start_realtime();
    
    time.sleep(5)

    antiMW.stop_realtime();
    antiMW.start_ondemand()

    time.sleep(5)

    antiMW.stop_ondemand()
    antiMW.start_realtime()
    
    time.sleep(5)

    antiMW.stop_realtime()

    time.sleep(5)

    printp.terminate()

    print 'Ended service ' + datetime.datetime.utcnow().strftime('%d-%m-%Y %H:%M:%S')

if __name__ == "__main__":
    main()