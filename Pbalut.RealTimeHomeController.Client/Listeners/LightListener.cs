using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using Pbalut.RealTimeHomeController.Shared.AppData;
using Pbalut.RealTimeHomeController.Shared.Enums.Extensions;
using Pbalut.RealTimeHomeController.Shared.Enums.Hubs;
using Pbalut.RealTimeHomeController.Shared.Models;

namespace Pbalut.RealTimeHomeController.Client.Listeners
{
    public class LightListener
    {
        public event EventHandler<LightEventInformation> LightInformationReceived;

        public async Task Init()
        {
            var hubConnection = new HubConnection(EndPoint.HubUrl);
            var hubProxy = hubConnection.CreateHubProxy(EHubMethod.LightSendInformation.GetHubName());
            hubProxy.On<LightEventInformation>(EHubMethod.LightSendInformation.GetClientName(),
                information => { LightInformationReceived?.Invoke(this, information); });
            await hubConnection.Start();
        }
    }
}