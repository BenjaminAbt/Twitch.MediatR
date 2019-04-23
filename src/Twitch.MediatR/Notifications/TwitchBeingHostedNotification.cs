using TwitchLib.Client.Models;

namespace BenjaminAbt.Twitch.MediatR.Notifications
{
    public class TwitchBeingHostedNotification : TwitchNotification
    {
        public BeingHostedNotification BeingHostedNotification { get; }

        public TwitchBeingHostedNotification(ITwitchChannelLink channelLink, BeingHostedNotification beingHostedNotification) : base(channelLink)
        {
            BeingHostedNotification = beingHostedNotification;
        }
    }
}