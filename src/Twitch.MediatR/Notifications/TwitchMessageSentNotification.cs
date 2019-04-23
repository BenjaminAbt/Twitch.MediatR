using TwitchLib.Client.Models;

namespace BenjaminAbt.Twitch.MediatR.Notifications
{
    public class TwitchMessageSentNotification : TwitchNotification
    {
        public SentMessage SentMessage { get; }

        public TwitchMessageSentNotification(ITwitchChannelLink channelLink, SentMessage sentMessage) : base(channelLink)
        {
            SentMessage = sentMessage;
        }
    }
}