using System.Reflection;
using BenjaminAbt.Twitch.MediatR.AspNetCore;
using BenjaminAbt.Twitch.MediatR.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace BenjaminAbt.TwitchChatBot.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTwitch(options => Configuration.Bind("Twitch", options),
                Assembly.GetAssembly(typeof(Startup)) // use current assembly, here are our handlers
                );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseTwitch();
        }
    }
}
