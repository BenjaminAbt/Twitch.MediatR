using TwitchLib.Client.Models;

namespace BenjaminAbt.Twitch.MediatR.Notifications
{
    public class TwitchGiftedSubscriptionNotification : TwitchNotification
    {
        public string Channel { get; }
        public GiftedSubscription GiftedSubscription { get; }

        public TwitchGiftedSubscriptionNotification(ITwitchChannelLink channelLink, string channel, GiftedSubscription giftedSubscription) : base(channelLink)
        {
            Channel = channel;
            GiftedSubscription = giftedSubscription;
        }
    }
}