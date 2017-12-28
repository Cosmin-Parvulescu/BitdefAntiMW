using Antimwpb;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AntiMwSdk.Core
{
    public class ThreatLogEvent
    {
        public DateTime? DateTime { get; set; }

        public ICollection<ThreatEvent> Threats { get; set; } = new List<ThreatEvent>();

        public static ThreatLogEvent Build(ThreatLogEventDto threatLogEventDto)
        {
            return new ThreatLogEvent
            {
                DateTime = threatLogEventDto.Timestamp.ToDateTime(),
                Threats = threatLogEventDto.ThreatEventDtos.Select(ted => ThreatEvent.Build(ted)).ToList(),
            };
        }
    }
}
