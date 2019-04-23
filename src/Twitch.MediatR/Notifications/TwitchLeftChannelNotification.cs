namespace BenjaminAbt.Twitch.MediatR.Notifications
{
    public class TwitchLeftChannelNotification : TwitchNotification
    {
        public string Channel { get; }
        public string BotUsername { get; }

        public TwitchLeftChannelNotification(ITwitchChannelLink channelLink, string channel, string botUsername) : base(channelLink)
        {
            Channel = channel;
            BotUsername = botUsername;
        }
    }
}