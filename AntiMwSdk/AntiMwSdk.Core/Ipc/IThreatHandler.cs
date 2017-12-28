using Antimwpb;

namespace AntiMwSdk.Core.Ipc
{
    public interface IThreatHandler
    {
        void Handle(ThreatEvent threatEventDto);
        void Handle(ThreatLogEvent threatLogEventDto);
        void Handle(LogEvent logEventDto);
    }
}