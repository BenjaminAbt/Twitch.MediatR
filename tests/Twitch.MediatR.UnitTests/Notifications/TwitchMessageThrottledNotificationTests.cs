using System;
using BenjaminAbt.Twitch.MediatR.Notifications;
using FluentAssertions;
using Moq;
using Xunit;

namespace BenjaminAbt.Twitch.MediatR.UnitTests.Notifications
{
    public class TwitchMessageThrottledNotificationTests
    {
        [Fact]
        public void PropertyTest()
        {
            Mock<ITwitchChannelLink> cLink = new Mock<ITwitchChannelLink>();

            TimeSpan timeSpan = new TimeSpan(1, 2, 3, 4);
            TwitchMessageThrottledNotification
                notification = new TwitchMessageThrottledNotification(cLink.Object, "Hello World", 999, timeSpan, 1);

            notification.ChannelLink.Should().NotBeNull();
            notification.ChannelLink.Should().Be(cLink.Object);
            notification.Message.Should().Be("Hello World");
            notification.AllowedInPeriod.Should().Be(999);
            notification.Period.Should().Be(timeSpan);
            notification.SentMessageCount.Should().Be(1);
        }
    }
}