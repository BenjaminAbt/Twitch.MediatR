using TwitchLib.Client.Models;

namespace BenjaminAbt.Twitch.MediatR.Notifications
{
    public class TwitchHostingStartedNotification : TwitchNotification
    {
        public HostingStarted HostingStarted { get; }

        public TwitchHostingStartedNotification(ITwitchChannelLink channelLink, HostingStarted hostingStarted) : base(channelLink)
        {
            HostingStarted = hostingStarted;
        }
    }
}