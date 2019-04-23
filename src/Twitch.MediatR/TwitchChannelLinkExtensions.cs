using System.Threading.Tasks;

namespace BenjaminAbt.Twitch.MediatR
{
    public static class TwitchChannelLinkExtensions
    {
        public static Task SendMessageAsync(this ITwitchChannelLink channelLink,string message, string channel, bool dryRun = false)
        {
            channelLink.Client.SendMessage(channel, message, dryRun);
            return Task.CompletedTask;
        }
    }
}