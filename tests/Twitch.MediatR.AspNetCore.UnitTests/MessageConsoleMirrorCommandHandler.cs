using System.IO;
using System.Threading;
using System.Threading.Tasks;
using BenjaminAbt.Twitch.MediatR.Notifications;
using MediatR;

namespace BenjaminAbt.Twitch.MediatR.AspNetCore.UnitTests
{
    public class MessageTestCommandHandler : INotificationHandler<TwitchChannelMessageNotification>
    {

        public Task Handle(TwitchChannelMessageNotification request, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
    }
}
