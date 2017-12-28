using Antimwpb;
using System;

namespace AntiMwSdk.Core
{
    public class ThreatEvent
    {
        public DateTime? DateTime { get; set; }

        public string Path { get; set; }

        public string Name { get; set; }

        public static ThreatEvent Build(ThreatEventDto threatEventDto)
        {
            return new ThreatEvent
            {
                DateTime = threatEventDto.Timestamp?.ToDateTime(),
                Name = threatEventDto.ThreatName,
                Path = threatEventDto.ThreatPath
            };
        }
    }
}
