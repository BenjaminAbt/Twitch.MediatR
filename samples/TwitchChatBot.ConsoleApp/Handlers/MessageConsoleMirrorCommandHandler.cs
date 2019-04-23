using System.IO;
using System.Threading;
using System.Threading.Tasks;
using BenjaminAbt.Twitch.MediatR.Notifications;
using MediatR;

namespace BenjaminAbt.TwitchChatBot.ConsoleApp.Handlers
{
    public class MessageConsoleMirrorCommandHandler : INotificationHandler<TwitchChannelMessageNotification>
    {
        private readonly TextWriter _output;

        public MessageConsoleMirrorCommandHandler(TextWriter output)
        {
            _output = output;
        }
        public async Task Handle(TwitchChannelMessageNotification request, CancellationToken cancellationToken = default)
        {
            string channel = request.ChatMessage.Channel;
            string user = request.ChatMessage.Username;
            string message = request.ChatMessage.Message;

            await _output.WriteLineAsync($"#{channel}: [{user}] {message}").ConfigureAwait(false); // string parameter does not support cancellation
        }
    }
}
