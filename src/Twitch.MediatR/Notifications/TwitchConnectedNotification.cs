namespace BenjaminAbt.Twitch.MediatR.Notifications
{
    public class TwitchConnectedNotification : TwitchNotification
    {
        public string BotUsername { get; }
        public string AutoJoinChannel { get; }

        public TwitchConnectedNotification(ITwitchChannelLink channelLink, string botUsername, string autoJoinChannel) : base(channelLink)
        {
            BotUsername = botUsername;
            AutoJoinChannel = autoJoinChannel;
        }
    }
}