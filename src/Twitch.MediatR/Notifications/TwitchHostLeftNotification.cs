using System;

namespace BenjaminAbt.Twitch.MediatR.Notifications
{
    public class TwitchHostLeftNotification : TwitchNotification
    {
        public EventArgs EventArgs { get; }

        public TwitchHostLeftNotification(ITwitchChannelLink channelLink, EventArgs eventArgs) : base(channelLink)
        {
            EventArgs = eventArgs;
        }
    }
}