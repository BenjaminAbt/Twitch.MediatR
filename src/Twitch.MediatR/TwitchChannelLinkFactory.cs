using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace BenjaminAbt.Twitch.MediatR
{
    public class TwitchChannelLinkProvider : ITwitchChannelLinkProvider
    {
        private Dictionary<ITwitchChannelLink, IServiceScope> _links = new Dictionary<ITwitchChannelLink, IServiceScope>();

        public TwitchChannelLinkProvider(ITwitchEventProxy eventProxy, IOptions<TwitchConfiguration> twitchOptions, IServiceProvider services)
        {
            TwitchConfiguration config = twitchOptions.Value;

            foreach (string channel in config.Channels)
            {
                // we need an own scope for each link
                IServiceScope scope = services.CreateScope();
                ITwitchChannelLink channelLink = new TwitchChannelLink(eventProxy, config.UserName, config.AcessToken, channel);


                _links.Add(channelLink, scope);
            }
        }

        /// <summary>
        /// Connects to channel links on application start
        /// </summary>
        public async Task StartAsync()
        {
            foreach (KeyValuePair<ITwitchChannelLink, IServiceScope> entry in _links)
            {
                ITwitchChannelLink link = entry.Key;

                await link.ConnectAsync()
                            .ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Disconnects channel links on application shutdown
        /// </summary>
        public async Task StopAsync()
        {
            foreach (KeyValuePair<ITwitchChannelLink, IServiceScope> entry in _links)
            {
                ITwitchChannelLink link = entry.Key;

                await link.DisconnectAsync()
                            .ConfigureAwait(false);
            }
        }

        public void Dispose()
        {
            if (_links != null)
            {
                StopAsync().GetAwaiter().GetResult();

                foreach (KeyValuePair<ITwitchChannelLink, IServiceScope> entry in _links)
                {
                    IServiceScope scope = entry.Value;

                    scope.Dispose();
                }

                _links = null;
            }
        }
    }
}
