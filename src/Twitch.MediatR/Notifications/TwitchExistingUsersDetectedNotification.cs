using System.Collections.Generic;

namespace BenjaminAbt.Twitch.MediatR.Notifications
{
    public class TwitchExistingUsersDetectedNotification : TwitchNotification
    {
        public string Channel { get; }
        public List<string> Users { get; }

        public TwitchExistingUsersDetectedNotification(ITwitchChannelLink channelLink, string channel, List<string> users) : base(channelLink)
        {
            Channel = channel;
            Users = users;
        }
    }
}