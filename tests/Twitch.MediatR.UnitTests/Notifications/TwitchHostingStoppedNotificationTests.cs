using BenjaminAbt.Twitch.MediatR.Notifications;
using FluentAssertions;
using Moq;
using TwitchLib.Client.Models;
using Xunit;

namespace BenjaminAbt.Twitch.MediatR.UnitTests.Notifications
{
    public class TwitchHostingStoppedNotificationTests
    {
        [Fact]
        public void PropertyTest()
        {
            Mock<ITwitchChannelLink> cLink = new Mock<ITwitchChannelLink>();


            HostingStopped hostingStopped = new HostingStopped("BenAbt", 1);
            TwitchHostingStoppedNotification
                notification = new TwitchHostingStoppedNotification(cLink.Object, hostingStopped);

            notification.ChannelLink.Should().NotBeNull();
            notification.ChannelLink.Should().Be(cLink.Object);
            notification.HostingStopped.Should().Be(hostingStopped);
        }
    }
}