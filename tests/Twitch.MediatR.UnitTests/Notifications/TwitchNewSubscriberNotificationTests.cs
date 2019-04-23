using System.Drawing;
using BenjaminAbt.Twitch.MediatR.Notifications;
using FluentAssertions;
using Moq;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Models;
using Xunit;

namespace BenjaminAbt.Twitch.MediatR.UnitTests.Notifications
{
    public class TwitchNewSubscriberNotificationTests
    {
        [Fact]
        public void PropertyTest()
        {
            Mock<ITwitchChannelLink> cLink = new Mock<ITwitchChannelLink>();

            Subscriber subscriber = new Subscriber(null, "", Color.Black, "Benjamin Abt",
                "", "", "", "", "", "", SubscriptionPlan.Prime,
                "", "", "", true, true, true, true, "", UserType.Admin, "", "");
            TwitchNewSubscriberNotification
                notification = new TwitchNewSubscriberNotification(cLink.Object, "BenAbt", subscriber);

            notification.ChannelLink.Should().NotBeNull();
            notification.ChannelLink.Should().Be(cLink.Object);
            notification.Channel.Should().Be("BenAbt");
            notification.Subscriber.Should().Be(subscriber);
        }
    }
}