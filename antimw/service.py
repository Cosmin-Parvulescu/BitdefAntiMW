from multiprocessing import Queue, Process
from Queue import Empty
from antimw import AntiMW

import time
import datetime
import sys

from eventprocessor import EventProcessor

def main():
    try:
        # There's a bug with strftime, it's not thread safe... https://bugs.python.org/issue7980
        # Apparently it becomes so if you use it before calling any threads, so I'm using this chance to do just that...
        print 'Starting service ' + datetime.datetime.utcnow().strftime('%d-%m-%Y %H:%M:%S')

        eventQueue = Queue()

        realtimeCommandQueue = Queue()
        ondemandCommandQueue = Queue()

        eventProc = EventProcessor()
        eventProcThread = Process(target = eventProc.process, args = (eventQueue, ))
        eventProcThread.start()

        antiMW = AntiMW(ondemandCommandQueue, realtimeCommandQueue, eventQueue)

        antiMW.start_realtime()

        raw_input()
    except:
        raise
    finally:
        antiMW.cleanup()
        eventProcThread.terminate()

        print 'Ended service ' + datetime.datetime.utcnow().strftime('%d-%m-%Y %H:%M:%S')

if __name__ == "__main__":
    main()