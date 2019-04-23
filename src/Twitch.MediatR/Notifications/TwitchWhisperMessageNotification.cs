using TwitchLib.Client.Models;

namespace BenjaminAbt.Twitch.MediatR.Notifications
{
    public class TwitchWhisperMessageNotification: TwitchNotification
    {
        public WhisperMessage WhisperMessage { get; }

        public TwitchWhisperMessageNotification(ITwitchChannelLink channelLink, WhisperMessage whisperMessage) : base(channelLink)
        {
            WhisperMessage = whisperMessage;
        }
    }
}