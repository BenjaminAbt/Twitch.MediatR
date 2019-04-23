using System.Drawing;
using BenjaminAbt.Twitch.MediatR.Notifications;
using FluentAssertions;
using Moq;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Models;
using Xunit;

namespace BenjaminAbt.Twitch.MediatR.UnitTests.Notifications
{
    public class TwitchWhisperMessageNotificationTests
    {
        [Fact]
        public void PropertyTest()
        {
            Mock<ITwitchChannelLink> cLink = new Mock<ITwitchChannelLink>();

            WhisperMessage whisperMessage = new WhisperMessage(null, "", Color.Black, "BenAbt",
                "", new EmoteSet("1:2-3", "Hello World"), "", "", "",
                true, "", "", UserType.Admin);

            TwitchWhisperMessageNotification
            notification = new TwitchWhisperMessageNotification(cLink.Object, whisperMessage);
            notification.ChannelLink.Should().NotBeNull();
            notification.ChannelLink.Should().Be(cLink.Object);
            notification.WhisperMessage.Should().Be(whisperMessage);
        }
    }
}