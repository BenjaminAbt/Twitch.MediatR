using MediatR;
using System.Threading;
using System.Threading.Tasks;
using BenjaminAbt.Twitch.MediatR;
using BenjaminAbt.Twitch.MediatR.Notifications;

namespace BenjaminAbt.TwitchChatBot.WebApp.Handlers
{
    public class TwitchChannelMessageNotificationHandler : INotificationHandler<TwitchChannelMessageNotification>
    {
        public async Task Handle(TwitchChannelMessageNotification request, CancellationToken cancellationToken = default)
        {
            string channel = request.ChatMessage.Channel;
            string response = $"Echo: {request.ChatMessage.Message}";

            await request.ChannelLink.SendMessageAsync(channel, response)
                            .ConfigureAwait(false);
        }
    }
}
