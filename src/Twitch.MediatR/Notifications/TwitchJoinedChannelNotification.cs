namespace BenjaminAbt.Twitch.MediatR.Notifications
{
    public class TwitchJoinedChannelNotification : TwitchNotification
    {
        public string Channel { get; }
        public string BotUsername { get; }

        public TwitchJoinedChannelNotification(ITwitchChannelLink channelLink, string channel, string botUsername) : base(channelLink)
        {
            Channel = channel;
            BotUsername = botUsername;
        }
    }
}