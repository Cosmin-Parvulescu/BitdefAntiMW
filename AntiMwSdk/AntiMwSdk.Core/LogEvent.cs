using Antimwpb;
using System;

namespace AntiMwSdk.Core
{
    public class LogEvent
    {
        public DateTime? DateTime { get; set; }

        public string Type { get; set; }

        public string Text { get; set; }

        public static LogEvent Build(LogEventDto logEventDto)
        {
            return new LogEvent
            {
                DateTime = logEventDto.Timestamp.ToDateTime(),
                Type = logEventDto.EventType,
                Text = logEventDto.AdditionalText
            };
        }
    }
}
