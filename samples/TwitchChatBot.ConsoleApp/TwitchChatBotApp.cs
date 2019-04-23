using System;
using System.Threading;
using System.Threading.Tasks;
using BenjaminAbt.Twitch.MediatR;
using Microsoft.Extensions.Hosting;

namespace BenjaminAbt.TwitchChatBot.ConsoleApp
{
    public class TwitchChatBotApp : IHostedService, IDisposable
    {
        private ITwitchChannelLinkProvider _twitchChannelLinkProvider;

        public TwitchChatBotApp(ITwitchChannelLinkProvider twitchChannelLinkProvider)
        {
            _twitchChannelLinkProvider = twitchChannelLinkProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _twitchChannelLinkProvider.StartAsync().ConfigureAwait(false);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _twitchChannelLinkProvider.StopAsync().ConfigureAwait(false);
        }

        public void Dispose()
        {
            if (_twitchChannelLinkProvider != null)
            {
                _twitchChannelLinkProvider.Dispose();
                _twitchChannelLinkProvider = null;
            }
        }
    }
}
