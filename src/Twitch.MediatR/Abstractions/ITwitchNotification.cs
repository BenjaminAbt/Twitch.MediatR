using MediatR;

namespace BenjaminAbt.Twitch.MediatR.Abstractions
{
    public interface ITwitchNotification : INotification, ITwitchEvent { }
}