using System;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.AspNet.SignalR.Client;
using Pbalut.RealTimeHomeController.Shared.AppData;
using Pbalut.RealTimeHomeController.Shared.Enums.Extensions;
using Pbalut.RealTimeHomeController.Shared.Enums.Groups;
using Pbalut.RealTimeHomeController.Shared.Enums.Hubs;
using Pbalut.RealTimeHomeController.Shared.Models;
using Pbalut.RealTimeHomeController.Shared.Models.Lights;
using Pbalut.Uwp.Commons.Exceptions.SignalR;
using Pbalut.Uwp.Commons.SignalR;

namespace Pbalut.RealTimeHomeController.Client.HubProxy
{
    public class LightHubProxy : HubProxyBase
    {
        public event EventHandler<LightServerResponse> LightInformationReceived;
        public event EventHandler<LightClientRequest> LightClientRequest;
        public event EventHandler<LightChangeStateError> LightError;

        public LightHubProxy()
            : base(EHub.Light.GetHubName())
        {
        }

        public async Task Start()
        {
            SetListeaners();
            await Init();
            HubProxy.On<LightServerResponse>(EHubMethod.LightInformAboutChangedState.GetClientName(),
                information => { LightInformationReceived?.Invoke(this, information); });
            HubProxy.On<LightClientRequest>(EHubMethod.LightChangeStateClientRequest.GetClientName(),
                clientRequest => { LightClientRequest?.Invoke(this, clientRequest); });
            HubProxy.On<LightChangeStateError>(EHubMethod.LightInformAboutErrorOccuredWhileChangingState.GetClientName(),
    error => { LightError?.Invoke(this, error); });
            await JoinToGroup();
            SetMessengesReciver();
        }

        private async Task JoinToGroup()
        {
            try
            {
                if (HubConnection.State != ConnectionState.Connected)
                    throw new InvalidHubConnectionStateException(EndPoint.HubUrl, HubConnection.State);
                await HubProxy.Invoke(EHubMethod.LightJoinGroup.GetServerName(), EGroup.Client);
            }
            catch (Exception ex)
            {
                //TODO            
            }
        }

        private void SetListeaners()
        {
            LightInformationReceived += async (p, q) =>
            {
                await AA(q);
            };

            LightClientRequest += async (p, q) =>
            {
                await AA1(q);
            };

            LightError += async (p, q) =>
            {
                await AA2(q);
            };
        }

        private void SetMessengesReciver()
        {
            Messenger.Default.Register<NotificationMessage<Light>>(this, async (message) =>
            {
                await SendRequestToChangeLightState(message.Content);
            });
        }

        private async Task SendRequestToChangeLightState(Light light)
        {
            try
            {
                if (HubConnection.State == ConnectionState.Connected)
                {
                    await HubProxy.Invoke(EHubMethod.LightChangeStateClientRequest.GetServerName(), light);
                }
            }
            catch (Exception ex)
            {
                //TODO            
            }
        }

        private async Task AA(LightServerResponse response)
        {
            
        }

        private async Task AA1(LightClientRequest response)
        {

        }

        private async Task AA2(LightChangeStateError response)
        {

        }
    }
}
