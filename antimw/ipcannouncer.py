import zmq

class IPCAnnouncer(object):
    def __init__(self):
        super(IPCAnnouncer, self).__init__()
        self.context = zmq.Context()
        self.socket = self.context.socket(zmq.PUB)
        self.socket.bind('tcp://*:1405')

    def cleanup(self):
        self.socket.close()
        self.context.term()