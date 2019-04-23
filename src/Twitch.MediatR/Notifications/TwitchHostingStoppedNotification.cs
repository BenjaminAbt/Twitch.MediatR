using TwitchLib.Client.Models;

namespace BenjaminAbt.Twitch.MediatR.Notifications
{
    public class TwitchHostingStoppedNotification : TwitchNotification
    {
        public HostingStopped HostingStopped { get; }

        public TwitchHostingStoppedNotification(ITwitchChannelLink channelLink, HostingStopped hostingStopped) : base(channelLink)
        {
            HostingStopped = hostingStopped;
        }
    }
}