using System;
using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BenjaminAbt.Twitch.MediatR.DependencyInjection
{
    public static class TwitchRegister
    {

        public static IServiceCollection AddTwitch(this IServiceCollection services, Action<TwitchConfiguration> twitchOptions, params Assembly[] mediatrAssemblies)
        {
            services.Configure(twitchOptions);

            services.AddScoped<ITwitchEventProxy, TwitchEventProxy>();
            services.AddScoped<ITwitchChannelLinkProvider,TwitchChannelLinkProvider>();
            services.AddTransient<ITwitchChannelLink, TwitchChannelLink>();

            services.AddMediatR(mediatrAssemblies);
            return services;
        }
    }
}
