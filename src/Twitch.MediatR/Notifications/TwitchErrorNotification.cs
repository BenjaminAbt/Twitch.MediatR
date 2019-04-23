using System;

namespace BenjaminAbt.Twitch.MediatR.Notifications
{
    public class TwitchErrorNotification : TwitchNotification
    {
        public Exception Exception { get; }

        public TwitchErrorNotification(ITwitchChannelLink channelLink, Exception exception) : base(channelLink)
        {
            Exception = exception;
        }
    }
}