using BenjaminAbt.Twitch.MediatR.Notifications;
using FluentAssertions;
using Moq;
using TwitchLib.Client.Models;
using Xunit;
using UserType = TwitchLib.Client.Enums.UserType;

namespace BenjaminAbt.Twitch.MediatR.UnitTests.Notifications
{
    public class TwitchGiftedSubscriptionNotificationTests
    {
        [Fact]
        public void PropertyTest()
        {
            Mock<ITwitchChannelLink> cLink = new Mock<ITwitchChannelLink>();


            GiftedSubscription giftedSubscription = new GiftedSubscription("badges", "color", "Benjamin Abt", "emotes", "1",
                "login", true, "msgId", "", "", "", "", "",
                TwitchLib.Client.Enums.SubscriptionPlan.Prime, "", true, "", "", "", true, UserType.Admin);
            TwitchGiftedSubscriptionNotification
                notification = new TwitchGiftedSubscriptionNotification(cLink.Object, "BenAbt", giftedSubscription);

            notification.ChannelLink.Should().NotBeNull();
            notification.ChannelLink.Should().Be(cLink.Object);
            notification.Channel.Should().Be("BenAbt");
            notification.GiftedSubscription.Should().Be(giftedSubscription);
        }
    }
}