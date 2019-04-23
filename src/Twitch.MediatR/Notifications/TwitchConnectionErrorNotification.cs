using TwitchLib.Client.Models;

namespace BenjaminAbt.Twitch.MediatR.Notifications
{
    public class TwitchConnectionErrorNotification : TwitchNotification
    {
        public string BotUsername { get; }
        public ErrorEvent Error { get; }

        public TwitchConnectionErrorNotification(ITwitchChannelLink channelLink, string botUsername, ErrorEvent error) : base(channelLink)
        {
            BotUsername = botUsername;
            Error = error;
        }
    }
}