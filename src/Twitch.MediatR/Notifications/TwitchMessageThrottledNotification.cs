using System;

namespace BenjaminAbt.Twitch.MediatR.Notifications
{
    public class TwitchMessageThrottledNotification : TwitchNotification
    {
        public string Message { get; }
        public int AllowedInPeriod { get; }
        public TimeSpan Period { get; }
        public int SentMessageCount { get; }

        public TwitchMessageThrottledNotification(ITwitchChannelLink channelLink, string message, int allowedInPeriod, TimeSpan period, int sentMessageCount) : base(channelLink)
        {
            Message = message;
            AllowedInPeriod = allowedInPeriod;
            Period = period;
            SentMessageCount = sentMessageCount;
        }
    }
}