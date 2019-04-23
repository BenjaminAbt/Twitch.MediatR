using BenjaminAbt.Twitch.MediatR.Abstractions;

namespace BenjaminAbt.Twitch.MediatR.Notifications
{
    public abstract class TwitchNotification : TwitchEvent, ITwitchNotification
    {
        protected TwitchNotification(ITwitchChannelLink channelLink) : base(channelLink) { }

    }
}