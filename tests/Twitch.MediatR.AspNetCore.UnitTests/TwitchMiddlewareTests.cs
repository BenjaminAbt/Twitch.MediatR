using System;
using System.Reflection;
using BenjaminAbt.Twitch.MediatR.Notifications;
using FluentAssertions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using TwitchLib.Client.Models;
using Xunit;

namespace BenjaminAbt.Twitch.MediatR.AspNetCore.UnitTests
{


    public class TwitchMiddlewareTests
    {
        [Fact]
        public void HandlerResolveTests()
        {
            Mock<ITwitchChannelLink> cLink = new Mock<ITwitchChannelLink>();


            IServiceCollection services = new ServiceCollection();

            // Register required services
            services.AddMediatR(Assembly.GetCallingAssembly()); // this assembly

            // Build provider
            IServiceProvider provider = services.BuildServiceProvider();

            // get handler
            IMediator mediatR = provider.GetRequiredService<IMediator>();
            mediatR.Publish(new TwitchChannelMessageNotification(cLink.Object, null));

        }
    }
}
