using System.Drawing;
using BenjaminAbt.Twitch.MediatR.Notifications;
using FluentAssertions;
using FluentAssertions.Common;
using Moq;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Models;
using Xunit;

namespace BenjaminAbt.Twitch.MediatR.UnitTests.Notifications
{
    public class TwitchChannelMessageNotificationTests
    {
        [Fact]
        public void PropertyTest()
        {
            Mock<ITwitchChannelLink> cLink = new Mock<ITwitchChannelLink>();
            cLink.SetupAllProperties();

            EmoteSet emoteSet = new EmoteSet("0:2-1", "Hello World");
            ChatMessage chatMessage = new ChatMessage("SchwabenCode", "123", "BenAbt", "Benjamin Abt", "001122",
                Color.Black, emoteSet,
                "Hello World", UserType.Admin, "BenAbt", "1", true, 1, "123", true, true, true, true, Noisy.True,
                "Hello Irc World", ":-)", null, new CheerBadge(1), 1, 1);

            TwitchChannelMessageNotification notification = new TwitchChannelMessageNotification(cLink.Object, chatMessage);

            notification.ChannelLink.Should().NotBeNull();
            notification.ChannelLink.Should().Be(cLink.Object);
            notification.ChatMessage.Should().NotBeNull();
            notification.ChatMessage.Should().IsSameOrEqualTo(chatMessage);
        }
    }
}