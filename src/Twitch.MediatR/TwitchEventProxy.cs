using System.Threading.Tasks;
using BenjaminAbt.Twitch.MediatR.Abstractions;
using MediatR;

namespace BenjaminAbt.Twitch.MediatR
{
    public class TwitchEventProxy : ITwitchEventProxy
    {

        private readonly IMediator _mediator;

        public TwitchEventProxy(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task PublishAsync<T>(T notification) where T : ITwitchNotification
        {
            await _mediator.Publish(notification).ConfigureAwait(false);
        }
    }
}