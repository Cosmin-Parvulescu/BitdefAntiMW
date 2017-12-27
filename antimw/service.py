from multiprocessing import Queue, Process
from Queue import Empty
from antimw import AntiMW

import time

def printer(eventQueue):
    while True:
        event = eventQueue.get()

        if event.evType == 'THREAT_FOUND':
            print 'REALTIME Threat found at ' + event.threat.path + ' | ' + event.threat.name
        elif event.evType == 'THREATS_FOUND':
            print 'ONDEMAND Threats found'
            for threat in event.threats:
                print threat.path + ' | ' + threat.name
        elif event.evType == 'ONDEMAND_START':
            print 'ONDEMAND scan started at ' + event.datetime.strftime('%d-%m-%Y %H:%M:%S')
        elif event.evType == 'ONDEMAND_STOP':
            print 'ONDEMAND scan stopped at ' + event.datetime.strftime('%d-%m-%Y %H:%M:%S') + ' with reason ' + event.reason
        elif event.evType == 'ONDEMAND_FINISH':
            print 'ONDEMAND scan finished at ' + event.datetime.strftime('%d-%m-%Y %H:%M:%S')
        else:
            print 'NO HANDLER FOR ' + event.evType

def main():
    eventQueue = Queue()

    realtimeCommandQueue = Queue()
    ondemandCommandQueue = Queue()

    printp = Process(target = printer, args = (eventQueue, ))
    printp.start()

    antiMW = AntiMW(ondemandCommandQueue, realtimeCommandQueue, eventQueue)

    antiMW.start_realtime();
    
    time.sleep(5)

    antiMW.start_ondemand()

    time.sleep(5)

    antiMW.stop_ondemand()

    time.sleep(5)

    antiMW.stop_realtime()

    time.sleep(5)

    printp.terminate()

if __name__ == "__main__":
    main()