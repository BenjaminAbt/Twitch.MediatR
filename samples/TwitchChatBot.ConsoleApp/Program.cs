using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using BenjaminAbt.Twitch.MediatR.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BenjaminAbt.TwitchChatBot.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IHostBuilder builder = new HostBuilder()
                            .ConfigureAppConfiguration((hostingContext, config) =>
                            {
                                config.SetBasePath(Directory.GetCurrentDirectory());
                                config.AddJsonFile("appsettings.json", optional: false);
                                config.AddJsonFile($"appsettings.{Environment.MachineName}.json", optional: true);

                            })
                            .ConfigureServices((hostingContext, services) =>
                            {
                                services.AddOptions();

                                // Register Twitch Middleware
                                services.AddTwitch(options => hostingContext.Configuration.GetSection("Twitch").Bind(options),
                                    Assembly.GetAssembly(typeof(TwitchChatBotApp)) // use current assembly, here are our handlers
                                );

                                // Register Log Ouput
                                services.AddTransient<TextWriter>(_=> Console.Out);

                                // Startup
                                services.AddHostedService<TwitchChatBotApp>();
                            })
                            .ConfigureLogging((hostingContext, logging) =>
                            {
                                logging.AddConfiguration(hostingContext.Configuration);
                                logging.AddConsole();
                            });

            await builder.RunConsoleAsync();
        }
    }
}
