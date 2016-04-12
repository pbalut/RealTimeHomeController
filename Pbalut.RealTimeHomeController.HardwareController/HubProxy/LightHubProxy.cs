using System;
using System.Linq;
using System.Threading.Tasks;
using Windows.Networking.Connectivity;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Transports;
using Pbalut.RealTimeHomeController.HardwareController.HardwareControllers;
using Pbalut.RealTimeHomeController.Shared.AppData;
using Pbalut.RealTimeHomeController.Shared.Enums;
using Pbalut.RealTimeHomeController.Shared.Enums.Extensions;
using Pbalut.RealTimeHomeController.Shared.Enums.Groups;
using Pbalut.RealTimeHomeController.Shared.Enums.Hubs;
using Pbalut.RealTimeHomeController.Shared.Models;
using Pbalut.RealTimeHomeController.Shared.Models.Lights;
using Pbalut.Uwp.Commons.Exceptions.SignalR;
using Pbalut.Uwp.Commons.SignalR;

namespace Pbalut.RealTimeHomeController.HardwareController.HubProxy
{
    public class LightHubProxy : HubProxyBase
    {
        internal event EventHandler<LightServerRequest> RequestToServerEvent;

        public LightHubProxy()
            : base(EHub.Light.GetHubName())
        {
        }

        public async Task Start()
        {
            try
            {
                await Init();
                HubProxy.On<LightServerRequest>(EHubMethod.LightChangeStateServerRequest.GetClientName(),
                    clientRequest => { RequestToServerEvent?.Invoke(this, clientRequest); });
                await JoinToGroup();
            }
            catch (Exception ex)
            {
                //TODO            
            }
        }

        private async Task JoinToGroup()
        {
            try
            {
                if (HubConnection.State != ConnectionState.Connected)
                    throw new InvalidHubConnectionStateException(EndPoint.HubUrl, HubConnection.State);
                await HubProxy.Invoke(EHubMethod.LightJoinGroup.GetServerName(), EGroup.Server);
            }
            catch (Exception ex)
            {
                //TODO            
            }
        }

        public async Task Execute(LightServerRequest request)
        {
            try
            {
                var currentState = RelayController.GetLightState(request.Type);
                RelayController.ChangeLightState(request.Type, request.State);
                await InformAboutChangedState(new LightServerResponse()
                {
                    Type = request.Type,
                    DateTime = DateTime.Now,
                    ServerName = NetworkInformation.GetHostNames().FirstOrDefault().DisplayName,
                    Source = request.Source,
                    UserName = request.UserName,
                    StateFrom = currentState,
                    StateTo = request.State
                });
            }
            catch (Exception ex)
            {
                //TODO
            }
        }

        private async Task InformAboutChangedState(LightServerResponse response)
        {
            try
            {
                if (HubConnection.State == ConnectionState.Connected)
                {
                    await HubProxy.Invoke(EHubMethod.LightInformAboutChangedState.GetServerName(), response);
                }
            }
            catch (Exception ex)
            {
                //TODO            
            }
        }
    }
}
