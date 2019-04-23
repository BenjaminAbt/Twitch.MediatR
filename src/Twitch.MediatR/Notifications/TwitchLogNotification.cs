using System;

namespace BenjaminAbt.Twitch.MediatR.Notifications
{
    public class TwitchLogNotification : TwitchNotification
    {
        public string BotUsername { get; }
        public string Data { get; }
        public DateTime DateTime { get; }

        public TwitchLogNotification(ITwitchChannelLink channelLink, string botUsername, string data, DateTime dateTime) : base(channelLink)
        {
            BotUsername = botUsername;
            Data = data;
            DateTime = dateTime;
        }
    }
}