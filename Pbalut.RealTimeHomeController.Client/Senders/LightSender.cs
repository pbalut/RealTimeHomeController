using System;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Transports;
using Pbalut.RealTimeHomeController.Client.Diagnostics;
using Pbalut.RealTimeHomeController.Shared.AppData;
using Pbalut.RealTimeHomeController.Shared.Enums.Extensions;
using Pbalut.RealTimeHomeController.Shared.Enums.Hubs;
using Pbalut.RealTimeHomeController.Shared.Models;

namespace Pbalut.RealTimeHomeController.Client.Senders
{
    public class LightSender
    {
        private HubConnection _hubConnection;
        private IHubProxy _hubProxy;

        public async Task Init()
        {
            try
            {
                _hubConnection = new HubConnection(EndPoint.HubUrl);

                var writer = new DebugTextWriter();
                _hubConnection.TraceWriter = writer;
                _hubConnection.TraceLevel = TraceLevels.All;

                _hubProxy = _hubConnection.CreateHubProxy(EHubMethod.LightChangeState.GetHubName());
                // LongPollingTransport: See http://www.4sln.com/Articles/creating-a-simple-application-using-universal-apps-with-signalr-and-mobile-servic
                await _hubConnection.Start(new LongPollingTransport());

                SetMessengerReciver();
            }
            catch (Exception e)
            {
            }
        }

        private void SetMessengerReciver()
        {
            Messenger.Default.Register<NotificationMessage<Light>>(this, async (message) =>
            {
                await SendRequestToChangeLightState(message.Content);
            });
        }

        public async Task SendRequestToChangeLightState(Light light)
        {
            try
            {
                if (_hubConnection.State == ConnectionState.Connected)
                {
                    await _hubProxy.Invoke(EHubMethod.LightChangeState.GetServerName(), light);
                }
            }
            catch (Exception ex)
            {
                //TODO            
            }
        }
    }
}