using TwitchLib.Client.Models;

namespace BenjaminAbt.Twitch.MediatR.Notifications
{
    public class TwitchChatCommandReceivedNotification : TwitchNotification
    {
        public ChatCommand Command { get; }

        public TwitchChatCommandReceivedNotification(ITwitchChannelLink channelLink, ChatCommand command) : base(channelLink)
        {
            Command = command;
        }
    }
}