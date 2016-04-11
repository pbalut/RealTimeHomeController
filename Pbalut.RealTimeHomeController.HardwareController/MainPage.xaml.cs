using System;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Pbalut.RealTimeHomeController.HardwareController.Engines;
using Pbalut.RealTimeHomeController.HardwareController.HardwareControllers;
using Pbalut.RealTimeHomeController.HardwareController.HubProxy;
using Pbalut.RealTimeHomeController.HardwareController.Listeners;
using Pbalut.RealTimeHomeController.Shared.Enums;
using Pbalut.RealTimeHomeController.Shared.Models.Lights;

namespace Pbalut.RealTimeHomeController.HardwareController
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            RelayController.InitializeRelayPins();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            var lightHubProxy = new LightHubProxy();
            lightHubProxy.RequestToServerEvent += async (p, q) =>
            {
                await lightHubProxy.Execute(q);
            };
            await lightHubProxy.Start();
        }

        private async Task LightClientRequestEvent(object sender)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                //    //GPIO
                //    RelayController.TurnOffLight(ELightType.PeterRoomMainLight);
                //    RelayController.TurnOnLight(ELightType.PeterRoomMainLight);
                //    //show events

                //    //send notification
            });
        }
    }
}
