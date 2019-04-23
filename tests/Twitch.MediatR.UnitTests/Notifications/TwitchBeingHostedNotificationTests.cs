using BenjaminAbt.Twitch.MediatR.Notifications;
using FluentAssertions;
using FluentAssertions.Common;
using Moq;
using TwitchLib.Client.Models;
using Xunit;

namespace BenjaminAbt.Twitch.MediatR.UnitTests.Notifications
{
    public class TwitchBeingHostedNotificationTests
    {
        [Fact]
        public void PropertyTest()
        {
            Mock<ITwitchChannelLink> cLink = new Mock<ITwitchChannelLink>();

            BeingHostedNotification eventArgs = new BeingHostedNotification("BenAbt", "SchwabenCode", "Twitch", 999, true);
            TwitchBeingHostedNotification notification = new TwitchBeingHostedNotification(cLink.Object, eventArgs);

            notification.ChannelLink.Should().NotBeNull();
            notification.ChannelLink.Should().Be(cLink.Object);
            notification.BeingHostedNotification.Should().NotBeNull();
            notification.BeingHostedNotification.Should().IsSameOrEqualTo(eventArgs);
        }
    }
}