using Antimwpb;
using System;

namespace AntiMwSdk.Core
{
    public interface IThreatHandler
    {
        void Handle(ThreatEventDto threatEventDto);
        void Handle(ThreatLogEventDto threatLogEventDto);
    }

    public class ThreatHandler : IThreatHandler
    {
        public void Handle(ThreatEventDto threatEventDto)
        {
            Console.WriteLine($"[{ threatEventDto.Timestamp?.ToDateTime().ToLocalTime() }] Real Time threat ({ threatEventDto.ThreatName }) detected @ { threatEventDto.ThreatPath }");
        }

        public void Handle(ThreatLogEventDto threatLogEventDto)
        {
            Console.WriteLine($"[{ threatLogEventDto.Timestamp.ToDateTime().ToLocalTime() }] On Demand scan threat log: ");
            foreach(var threatLog in threatLogEventDto.ThreatEventDtos)
            {
                Handle(threatLog);
            }
        }
    }
}