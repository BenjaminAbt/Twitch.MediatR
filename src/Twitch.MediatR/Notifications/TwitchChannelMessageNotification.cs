using TwitchLib.Client.Models;

namespace BenjaminAbt.Twitch.MediatR.Notifications
{
    public class TwitchChannelMessageNotification : TwitchNotification
    {
        public TwitchChannelMessageNotification(ITwitchChannelLink channelLink, ChatMessage chatMessage) : base(channelLink)
        {
            ChatMessage = chatMessage;
        }

        public ChatMessage ChatMessage { get; }
    }
}