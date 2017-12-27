import datetime

class Event(object):
    def __init__(self, evType):
        super(Event, self).__init__()
        self.evType = evType
        self.datetime = datetime.datetime.utcnow()

class ThreatEvent(Event):
    def __init__(self, threat):       
        super(ThreatEvent, self).__init__('THREAT_FOUND')

        self.threat = threat

class ThreatLogEvent(Event):
    def __init__(self, threats):
        super(ThreatLogEvent, self).__init__('THREATS_FOUND')

        self.threats = threats

class OnDemandStartEvent(Event):
     def __init__(self):
        super(OnDemandStartEvent, self).__init__('ONDEMAND_START')

class OnDemandFinishEvent(Event):
     def __init__(self):
        super(OnDemandFinishEvent, self).__init__('ONDEMAND_FINISH')

class OnDemandStopEvent(Event):
     def __init__(self, reason):
        super(OnDemandStopEvent, self).__init__('ONDEMAND_STOP')

        self.reason = reason