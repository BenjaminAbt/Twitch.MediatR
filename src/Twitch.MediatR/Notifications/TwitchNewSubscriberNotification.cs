using TwitchLib.Client.Models;

namespace BenjaminAbt.Twitch.MediatR.Notifications
{
    public class TwitchNewSubscriberNotification : TwitchNotification
    {
        public string Channel { get; }
        public Subscriber Subscriber { get; }

        public TwitchNewSubscriberNotification(ITwitchChannelLink channelLink, string channel, Subscriber subscriber) : base(channelLink)
        {
            Channel = channel;
            Subscriber = subscriber;
        }
    }
}