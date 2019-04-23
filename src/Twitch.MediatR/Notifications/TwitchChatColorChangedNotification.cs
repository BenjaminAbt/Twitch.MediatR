namespace BenjaminAbt.Twitch.MediatR.Notifications
{
    public class TwitchChatColorChangedNotification : TwitchNotification
    {
        public string Channel { get; }

        public TwitchChatColorChangedNotification(ITwitchChannelLink channelLink, string channel) : base(channelLink)
        {
            Channel = channel;
        }
    }
}