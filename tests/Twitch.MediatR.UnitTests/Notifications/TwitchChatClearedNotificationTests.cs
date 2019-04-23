using BenjaminAbt.Twitch.MediatR.Notifications;
using FluentAssertions;
using Moq;
using Xunit;

namespace BenjaminAbt.Twitch.MediatR.UnitTests.Notifications
{
    public class TwitchChatClearedNotificationTests
    {
        [Fact]
        public void PropertyTest()
        {
            Mock<ITwitchChannelLink> cLink = new Mock<ITwitchChannelLink>();

            TwitchChatClearedNotification
                notification = new TwitchChatClearedNotification(cLink.Object, "BenAbt");

            notification.ChannelLink.Should().NotBeNull();
            notification.ChannelLink.Should().Be(cLink.Object);
            notification.Channel.Should().Be("BenAbt");
        }
    }
}