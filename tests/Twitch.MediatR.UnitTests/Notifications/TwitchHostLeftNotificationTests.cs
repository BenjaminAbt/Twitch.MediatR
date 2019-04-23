using System;
using BenjaminAbt.Twitch.MediatR.Notifications;
using FluentAssertions;
using Moq;
using Xunit;

namespace BenjaminAbt.Twitch.MediatR.UnitTests.Notifications
{
    public class TwitchHostLeftNotificationTests
    {
        [Fact]
        public void PropertyTest()
        {
            Mock<ITwitchChannelLink> cLink = new Mock<ITwitchChannelLink>();

            EventArgs eventArgs = new EventArgs();
            TwitchHostLeftNotification
                notification = new TwitchHostLeftNotification(cLink.Object, eventArgs);

            notification.ChannelLink.Should().NotBeNull();
            notification.ChannelLink.Should().Be(cLink.Object);
            notification.EventArgs.Should().Be(eventArgs);
        }
    }
}