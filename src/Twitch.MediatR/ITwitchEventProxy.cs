using System.Threading.Tasks;
using BenjaminAbt.Twitch.MediatR.Abstractions;

namespace BenjaminAbt.Twitch.MediatR
{
    public interface ITwitchEventProxy
    {
        Task PublishAsync<T>(T notification) where T : ITwitchNotification;
    }
}