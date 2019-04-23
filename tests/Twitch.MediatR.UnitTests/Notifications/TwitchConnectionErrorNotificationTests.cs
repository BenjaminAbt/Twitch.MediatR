using BenjaminAbt.Twitch.MediatR.Notifications;
using FluentAssertions;
using Moq;
using TwitchLib.Client.Models;
using Xunit;

namespace BenjaminAbt.Twitch.MediatR.UnitTests.Notifications
{
    public class TwitchConnectionErrorNotificationTests
    {
        [Fact]
        public void PropertyTest()
        {
            Mock<ITwitchChannelLink> cLink = new Mock<ITwitchChannelLink>();

            ErrorEvent errorEvent = new ErrorEvent();
            TwitchConnectionErrorNotification
                notification = new TwitchConnectionErrorNotification(cLink.Object, "SchwabenCode", errorEvent);

            notification.ChannelLink.Should().NotBeNull();
            notification.ChannelLink.Should().Be(cLink.Object);
            notification.BotUsername.Should().Be("SchwabenCode");
            notification.Error.Should().Be(errorEvent);
        }
    }
}