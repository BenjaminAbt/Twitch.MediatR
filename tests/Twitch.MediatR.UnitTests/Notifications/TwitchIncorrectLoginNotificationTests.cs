using BenjaminAbt.Twitch.MediatR.Notifications;
using FluentAssertions;
using Moq;
using TwitchLib.Client.Exceptions;
using Xunit;

namespace BenjaminAbt.Twitch.MediatR.UnitTests.Notifications
{
    public class TwitchIncorrectLoginNotificationTests
    {
        [Fact]
        public void PropertyTest()
        {
            Mock<ITwitchChannelLink> cLink = new Mock<ITwitchChannelLink>();

            ErrorLoggingInException exception = new ErrorLoggingInException("ircData", "BenAbt");
            TwitchIncorrectLoginNotification
                notification = new TwitchIncorrectLoginNotification(cLink.Object, exception);

            notification.ChannelLink.Should().NotBeNull();
            notification.ChannelLink.Should().Be(cLink.Object);
            notification.Exception.Should().Be(exception);
        }
    }
}