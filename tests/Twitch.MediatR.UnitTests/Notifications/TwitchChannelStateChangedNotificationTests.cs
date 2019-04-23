using System;
using BenjaminAbt.Twitch.MediatR.Notifications;
using FluentAssertions;
using Moq;
using TwitchLib.Client.Models;
using Xunit;

namespace BenjaminAbt.Twitch.MediatR.UnitTests.Notifications
{
    public class TwitchChannelStateChangedNotificationTests
    {
        [Fact]
        public void PropertyTest()
        {
            Mock<ITwitchChannelLink> cLink = new Mock<ITwitchChannelLink>();

            ChannelState channelState = new ChannelState(true, true, true, 1, true, "de", "BenAbt", TimeSpan.Zero, true, "123");
            TwitchChannelStateChangedNotification notification = new TwitchChannelStateChangedNotification(cLink.Object, "BenAbt", channelState);

            notification.ChannelLink.Should().NotBeNull();
            notification.ChannelLink.Should().Be(cLink.Object);
            notification.Channel.Should().Be("BenAbt");
            notification.ChannelState.Should().Be(channelState);
        }
    }
}