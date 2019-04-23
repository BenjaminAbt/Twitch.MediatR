using TwitchLib.Client.Exceptions;

namespace BenjaminAbt.Twitch.MediatR.Notifications
{
    public class TwitchIncorrectLoginNotification : TwitchNotification
    {
        public ErrorLoggingInException Exception { get; }

        public TwitchIncorrectLoginNotification(ITwitchChannelLink channelLink, ErrorLoggingInException exception) : base(channelLink)
        {
            Exception = exception;
        }
    }
}