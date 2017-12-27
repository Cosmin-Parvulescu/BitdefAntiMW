from multiprocessing import Queue, Process
from Queue import Empty
from antimw import AntiMW

import time
import datetime
import sys

import zmq

from eventprocessor import EventProcessor

def main():
    try:
        context = zmq.Context()
        socket = context.socket(zmq.REP)

        socket.bind('tcp://*:2804')

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

        while True:
            try:
                message = socket.recv(zmq.NOBLOCK)
                rephrase = False

                res = 'OK'

                print 'Received request: ' + message

                if message == 'START_REALTIME':
                    mwRes = antiMW.start_realtime()
                    if mwRes == -1:
                        res = 'ALREADY_RUNNING'
                elif message == 'STOP_REALTIME':
                    mwRes = antiMW.stop_realtime()
                    if mwRes == -1:
                        res = 'NOT_RUNNING'
                elif message == 'START_ONDEMAND':
                    mwRes = antiMW.start_ondemand()
                    if mwRes == -1:
                        res = 'ALREADY_RUNNING'
                elif message == 'STOP_ONDEMAND':
                    mwRes = antiMW.start_ondemand()
                    if mwRes == -1:
                        res = 'NOT_RUNNING'
                else:
                    res = 'REPHRASE'

                socket.send(res)
                print 'Responded with: ', res
            except zmq.error.Again:
                pass

            time.sleep(0)

        raw_input()
    except:
        raise
    finally:
        socket.close()
        context.term()

        antiMW.cleanup()
        eventProcThread.terminate()

        print 'Ended service ' + datetime.datetime.utcnow().strftime('%d-%m-%Y %H:%M:%S')

if __name__ == "__main__":
    main()