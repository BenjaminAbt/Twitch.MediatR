namespace BenjaminAbt.Twitch.MediatR.Abstractions
{
    public abstract class TwitchEvent : ITwitchEvent
    {
        public ITwitchChannelLink ChannelLink { get; }

        protected TwitchEvent(ITwitchChannelLink channelLink)
        {
            ChannelLink = channelLink;
        }

    }
}