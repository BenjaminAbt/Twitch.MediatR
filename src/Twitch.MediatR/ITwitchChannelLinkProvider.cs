using System;
using System.Threading.Tasks;

namespace BenjaminAbt.Twitch.MediatR
{
    public interface ITwitchChannelLinkProvider : IDisposable
    {
        Task StartAsync();
        Task StopAsync();
    }
}