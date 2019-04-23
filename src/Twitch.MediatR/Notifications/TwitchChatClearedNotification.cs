namespace BenjaminAbt.Twitch.MediatR.Notifications
{
    public class TwitchChatClearedNotification : TwitchNotification
    {
        public string Channel { get; }

        public TwitchChatClearedNotification(ITwitchChannelLink channelLink, string channel) : base(channelLink)
        {
            Channel = channel;
        }
    }
}