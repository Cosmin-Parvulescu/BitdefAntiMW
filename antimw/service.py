from multiprocessing import Queue, Process
from Queue import Empty
from antimw import AntiMW

import time

def printer(eventQueue):
    while True:
        print eventQueue.get()

def main():
    eventQueue = Queue()
    realtimeCommandQueue = Queue()
    ondemandCommandQueue = Queue()

    printp = Process(target = printer, args = (eventQueue, ))
    printp.start()

    antiMW = AntiMW(ondemandCommandQueue, realtimeCommandQueue, eventQueue)

    antiMW.start_ondemand()
    time.sleep(5)
    antiMW.stop_ondemand()

    printp.terminate()

if __name__ == "__main__":
    main()