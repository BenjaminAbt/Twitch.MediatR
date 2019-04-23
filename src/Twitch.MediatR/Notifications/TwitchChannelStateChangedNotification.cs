using TwitchLib.Client.Models;

namespace BenjaminAbt.Twitch.MediatR.Notifications
{
    public class TwitchChannelStateChangedNotification : TwitchNotification
    {
        public string Channel { get; }
        public ChannelState ChannelState { get; }

        public TwitchChannelStateChangedNotification(ITwitchChannelLink channelLink, string channel, ChannelState channelState) : base(channelLink)
        {
            Channel = channel;
            ChannelState = channelState;
        }
    }
}