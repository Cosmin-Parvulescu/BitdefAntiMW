class Event(object):
    def __init__(self, evType):
        super(Event, self).__init__()
        self.evType = evType

class ThreatEvent(Event):
    def __init__(self, threat):       
        super(ThreatEvent, self).__init__('THREAT_FOUND')

        self.threat = threat

class ThreatLogEvent(Event):
    def __init__(self, threats):
        super(ThreatLogEvent, self).__init__('THREATS_FOUND')

        self.threats = threats

class OnDemandStartEvent(Event):
     def __init__(self, datetime):
        super(OnDemandStartEvent, self).__init__('ONDEMAND_START')

        self.datetime = datetime

class OnDemandFinishEvent(Event):
     def __init__(self, datetime):
        super(OnDemandFinishEvent, self).__init__('ONDEMAND_FINISH')

        self.datetime = datetime

class OnDemandStopEvent(Event):
     def __init__(self, datetime, reason):
        super(OnDemandStopEvent, self).__init__('ONDEMAND_STOP')

        self.datetime = datetime
        self.reason = reason