using TwitchLib.Communication.Events;

namespace BenjaminAbt.Twitch.MediatR.Notifications
{
    public class TwitchDisconnectedNotification : TwitchNotification
    {
        public OnDisconnectedEventArgs DisconnectedEventArgs { get; }

        public TwitchDisconnectedNotification(ITwitchChannelLink channelLink, OnDisconnectedEventArgs disconnectedEventArgs) : base(channelLink)
        {
            DisconnectedEventArgs = disconnectedEventArgs;
        }
    }
}