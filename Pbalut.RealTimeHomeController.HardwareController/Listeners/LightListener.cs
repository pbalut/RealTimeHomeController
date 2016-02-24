using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using Pbalut.RealTimeHomeController.Shared.AppData;
using Pbalut.RealTimeHomeController.Shared.Enums.Extensions;
using Pbalut.RealTimeHomeController.Shared.Enums.Hubs;
using Pbalut.RealTimeHomeController.Shared.Models;

namespace Pbalut.RealTimeHomeController.HardwareController.Listeners
{
    public class LightListener
    {
        public event EventHandler<Light> LightDataReceived;

        public async Task Init()
        {
            var hubConnection = new HubConnection(EndPoint.HubUrl);
            var hubProxy = hubConnection.CreateHubProxy(EHubMethod.LightChangeStateClientRequest.GetHubName());
            hubProxy.On<Light>(EHubMethod.LightChangeStateClientRequest.GetClientName(), data =>
            {
                LightDataReceived?.Invoke(this, data);
            });
            await hubConnection.Start();
        }
    }
}
