using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Transports;
using Pbalut.RealTimeHomeController.Shared.AppData;
using Pbalut.Uwp.Commons.Diagnostics;

namespace Pbalut.Uwp.Commons.SignalR
{
    public class HubProxyBase
    {
        protected readonly HubConnection HubConnection;
        protected readonly IHubProxy HubProxy;

        protected HubProxyBase(string hubName)
        {
            HubConnection = new HubConnection(EndPoint.HubUrl);
            HubProxy = HubConnection.CreateHubProxy(hubName);
            var writer = new DebugTextWriter();
            HubConnection.TraceWriter = writer;
            HubConnection.TraceLevel = TraceLevels.All;
        }

        protected async Task Init(IClientTransport transportWay = null)
        {
            if (transportWay != null)
            {
                await HubConnection.Start(new LongPollingTransport());
            }
            else
            {
                await HubConnection.Start();
            }
        }
    }
}
