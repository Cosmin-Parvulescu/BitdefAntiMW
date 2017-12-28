from multiprocessing import Queue, Process
from Queue import Empty

import zmq

import time

class IPCAPI(Process):
    def __init__(self, antiMW):
        super(IPCAPI, self).__init__()

        self.antiMW = antiMW
        self.commandQueue = Queue()

    def run(self):
        context = zmq.Context()
        socket = context.socket(zmq.REP)

        socket.bind('tcp://*:2804')

        while True:
            try:
                command = self.commandQueue.get_nowait()
                if command is not None:
                    if command == 'STOP':
                        break
            except Empty:
                pass

            try:
                message = socket.recv(zmq.NOBLOCK)
                rephrase = False

                res = 'OK'

                print 'Received request: ' + message

                if message == 'START_REALTIME':
                    mwRes = self.antiMW.start_realtime()
                    if mwRes == -1:
                        res = 'ALREADY_RUNNING'
                elif message == 'STOP_REALTIME':
                    mwRes = self.antiMW.stop_realtime()
                    if mwRes == -1:
                        res = 'NOT_RUNNING'
                elif message == 'START_ONDEMAND':
                    mwRes = self.antiMW.start_ondemand()
                    if mwRes == -1:
                        res = 'ALREADY_RUNNING'
                elif message == 'STOP_ONDEMAND':
                    mwRes = self.antiMW.stop_ondemand()
                    if mwRes == -1:
                        res = 'NOT_RUNNING'
                else:
                    res = 'REPHRASE'

                socket.send(res)

                print 'Responded with: ', res
            except zmq.error.Again:
                pass

            time.sleep(1)

        socket.close()
        context.term()
            
    def cleanup(self):
        self.commandQueue.put('STOP')