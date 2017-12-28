using Antimwpb;
using System;

namespace AntiMwSdk.Core
{
    public interface IThreatHandler
    {
        void Handle(ThreatEventDto threatEventDto);
    }

    public class ThreatHandler : IThreatHandler
    {
        public void Handle(ThreatEventDto threatEventDto)
        {
            Console.WriteLine($"[{ threatEventDto.Timestamp.ToDateTime().ToLocalTime() }] Threat ({ threatEventDto.ThreatName }) detected @ { threatEventDto.ThreatPath }");
        }
    }
}