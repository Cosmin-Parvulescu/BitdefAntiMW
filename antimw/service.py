from multiprocessing import Queue, Process
from antimw import AntiMW

import datetime

from ipcapi import IPCAPI
from eventsink import EventSink

def main():
    try:
        # There's a bug with strftime, it's not thread safe... https://bugs.python.org/issue7980
        # Apparently it becomes so if you use it before calling any threads, so I'm using this chance to do just that...
        print 'Starting service ' + datetime.datetime.utcnow().strftime('%d-%m-%Y %H:%M:%S')

        eventQueue = Queue()

        realtimeCommandQueue = Queue()
        ondemandCommandQueue = Queue()

        eventSink = EventSink(eventQueue)
        eventSink.start()

        antiMW = AntiMW(ondemandCommandQueue, realtimeCommandQueue, eventQueue)

        ipcapi = IPCAPI(antiMW)
        ipcapi.start()
        
        raw_input()
    except:
        raise
    finally:
        ipcapi.cleanup()
        antiMW.cleanup()
        eventSink.cleanup()

        ipcapi.join()
        eventSink.join()

        print 'Ended service ' + datetime.datetime.utcnow().strftime('%d-%m-%Y %H:%M:%S')

if __name__ == "__main__":
    main()