using System;
using System.Threading.Tasks;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using BenjaminAbt.Twitch.MediatR.Notifications;
using TwitchLib.Client.Interfaces;
using TwitchLib.Communication.Events;

namespace BenjaminAbt.Twitch.MediatR
{
    public interface ITwitchChannelLink
    {
        Task ConnectAsync();
        Task DisconnectAsync();
        ITwitchClient Client { get; }
    }

    public class TwitchChannelLink : ITwitchChannelLink
    {
        private readonly ITwitchEventProxy _eventProxy;
        public ITwitchClient Client { get; }

        public Task ConnectAsync()
        {
            Client.Connect();
            return Task.CompletedTask;
        }

        public Task DisconnectAsync()
        {
            Client.Disconnect();
            return Task.CompletedTask;
        }

        public TwitchChannelLink(ITwitchEventProxy eventProxy, string userName, string accessToken, string channel)
        {
            _eventProxy = eventProxy;
            Client = new TwitchClient();

            Client.OnConnected += Client_OnConnected;
            Client.OnBeingHosted += Client_OnBeingHosted;
            Client.OnChannelStateChanged += Client_OnChannelStateChanged;
            Client.OnChatCleared += Client_OnChatCleared;
            Client.OnChatColorChanged += Client_OnChatColorChanged;
            Client.OnChatCommandReceived += Client_OnChatCommandReceived;
            Client.OnConnectionError += Client_OnConnectionError;
            Client.OnDisconnected += Client_OnDisconnected;
            Client.OnExistingUsersDetected += Client_OnExistingUsersDetected;
            Client.OnGiftedSubscription += Client_OnGiftedSubscription;
            Client.OnHostingStarted += Client_OnHostingStarted;
            Client.OnHostingStopped += Client_OnHostingStopped;
            Client.OnHostLeft += Client_OnHostLeft;
            Client.OnIncorrectLogin += Client_OnIncorrectLogin;
            Client.OnJoinedChannel += Client_OnJoinedChannel;
            Client.OnLeftChannel += Client_OnLeftChannel;
            Client.OnLog += Client_OnLog;
            Client.OnMessageSent += Client_OnMessageSent;
            Client.OnMessageThrottled += Client_OnMessageThrottled;
            Client.OnMessageReceived += Client_OnMessageReceived;
            Client.OnWhisperReceived += Client_OnWhisperReceived;
            Client.OnNewSubscriber += Client_OnNewSubscriber;
            Client.OnError += Client_OnError;

            // Token by https://github.com/swiftyspiffy/twitch-token-generator
            ConnectionCredentials credentials = new ConnectionCredentials(userName, accessToken);
            Client.Initialize(credentials, channel);
        }

        private async void Client_OnMessageThrottled(object sender, OnMessageThrottledEventArgs e)
        {
            await _eventProxy.PublishAsync(new TwitchMessageThrottledNotification(this, e.Message, e.AllowedInPeriod, e.Period, e.SentMessageCount))
                .ConfigureAwait(false);
        }

        private async void Client_OnMessageSent(object sender, OnMessageSentArgs e)
        {
            await _eventProxy.PublishAsync(new TwitchMessageSentNotification(this, e.SentMessage))
                .ConfigureAwait(false);
        }

        private async void Client_OnLeftChannel(object sender, OnLeftChannelArgs e)
        {
            await _eventProxy.PublishAsync(new TwitchLeftChannelNotification(this, e.Channel, e.BotUsername))
                .ConfigureAwait(false);
        }

        private async void Client_OnIncorrectLogin(object sender, OnIncorrectLoginArgs e)
        {
            await _eventProxy.PublishAsync(new TwitchIncorrectLoginNotification(this, e.Exception))
                .ConfigureAwait(false);
        }

        private async void Client_OnHostLeft(object sender, EventArgs e)
        {
            await _eventProxy.PublishAsync(new TwitchHostLeftNotification(this, e))
                .ConfigureAwait(false);
        }

        private async void Client_OnHostingStopped(object sender, OnHostingStoppedArgs e)
        {
            await _eventProxy.PublishAsync(new TwitchHostingStoppedNotification(this, e.HostingStopped))
                .ConfigureAwait(false);
        }

        private async void Client_OnHostingStarted(object sender, OnHostingStartedArgs e)
        {
            await _eventProxy.PublishAsync(new TwitchHostingStartedNotification(this, e.HostingStarted))
                .ConfigureAwait(false);
        }

        private async void Client_OnGiftedSubscription(object sender, OnGiftedSubscriptionArgs e)
        {
            await _eventProxy.PublishAsync(new TwitchGiftedSubscriptionNotification(this, e.Channel, e.GiftedSubscription))
                .ConfigureAwait(false);
        }

        private async void Client_OnExistingUsersDetected(object sender, OnExistingUsersDetectedArgs e)
        {
            await _eventProxy.PublishAsync(new TwitchExistingUsersDetectedNotification(this, e.Channel, e.Users))
                .ConfigureAwait(false);
        }

        private async void Client_OnDisconnected(object sender, OnDisconnectedEventArgs e)
        {
            await _eventProxy.PublishAsync(new TwitchDisconnectedNotification(this, e))
                .ConfigureAwait(false);
        }

        private async void Client_OnConnectionError(object sender, OnConnectionErrorArgs e)
        {
            await _eventProxy.PublishAsync(new TwitchConnectionErrorNotification(this, e.BotUsername, e.Error))
                .ConfigureAwait(false);
        }

        private async void Client_OnChatCommandReceived(object sender, OnChatCommandReceivedArgs e)
        {
            await _eventProxy.PublishAsync(new TwitchChatCommandReceivedNotification(this, e.Command))
                .ConfigureAwait(false);
        }

        private async void Client_OnChatColorChanged(object sender, OnChatColorChangedArgs e)
        {
            await _eventProxy.PublishAsync(new TwitchChatColorChangedNotification(this, e.Channel))
                .ConfigureAwait(false);
        }

        private async void Client_OnChatCleared(object sender, OnChatClearedArgs e)
        {
            await _eventProxy.PublishAsync(new TwitchChatClearedNotification(this, e.Channel))
                .ConfigureAwait(false);
        }

        private async void Client_OnChannelStateChanged(object sender, OnChannelStateChangedArgs e)
        {
            await _eventProxy.PublishAsync(new TwitchChannelStateChangedNotification(this, e.Channel, e.ChannelState))
                .ConfigureAwait(false);
        }

        private async void Client_OnBeingHosted(object sender, OnBeingHostedArgs e)
        {
            await _eventProxy.PublishAsync(new TwitchBeingHostedNotification(this, e.BeingHostedNotification))
                .ConfigureAwait(false);
        }

        private async void Client_OnError(object sender, OnErrorEventArgs e)
        {
            await _eventProxy.PublishAsync(new TwitchErrorNotification(this, e.Exception))
                .ConfigureAwait(false);
        }

        private async void Client_OnLog(object sender, OnLogArgs e)
        {
            await _eventProxy.PublishAsync(new TwitchLogNotification(this, e.BotUsername, e.Data, e.DateTime))
                .ConfigureAwait(false);
        }

        private async void Client_OnConnected(object sender, OnConnectedArgs e)
        {
            await _eventProxy.PublishAsync(new TwitchConnectedNotification(this, e.BotUsername, e.AutoJoinChannel))
                .ConfigureAwait(false);
        }

        private async void Client_OnJoinedChannel(object sender, OnJoinedChannelArgs e)
        {
            await _eventProxy.PublishAsync(new TwitchJoinedChannelNotification(this, e.Channel, e.BotUsername))
                .ConfigureAwait(false);
        }

        private async void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            await _eventProxy.PublishAsync(new TwitchChannelMessageNotification(this, e.ChatMessage))
                            .ConfigureAwait(false);
        }


        private async void Client_OnWhisperReceived(object sender, OnWhisperReceivedArgs e)
        {
            await _eventProxy.PublishAsync(new TwitchWhisperMessageNotification(this, e.WhisperMessage))
                .ConfigureAwait(false);
        }

        private async void Client_OnNewSubscriber(object sender, OnNewSubscriberArgs e)
        {
            await _eventProxy.PublishAsync(new TwitchNewSubscriberNotification(this, e.Channel, e.Subscriber))
                .ConfigureAwait(false);
        }
    }
}
