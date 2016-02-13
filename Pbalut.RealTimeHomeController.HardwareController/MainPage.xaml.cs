using System;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Pbalut.RealTimeHomeController.HardwareController.Engines;
using Pbalut.RealTimeHomeController.HardwareController.HardwareControllers;
using Pbalut.RealTimeHomeController.HardwareController.HubProxy;
using Pbalut.RealTimeHomeController.HardwareController.Listeners;

namespace Pbalut.RealTimeHomeController.HardwareController
{
    public sealed partial class MainPage : Page
    {
        #region Listeners
        private LightListener LightListner { get; set; }
        #endregion

        #region Engines
        private LightEngine LightEngine { get; set; }
        #endregion

        public MainPage()
        {
            this.InitializeComponent();
            LightEngine = LightEngine.GetLightEngine();
            RelayController.InitializeRelayPins();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            var lightHubProxy = new LightHubProxy();
            lightHubProxy.LightClientRequest += async (p, q) =>
            {
                await LightClientRequestEvent(q);
            };
            await lightHubProxy.Start();
        }

        private async Task LightClientRequestEvent(object sender)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                //    LightEngine.Field = q.State.ToString();
                //    var t = 2;
                //    //GPIO
                //    RelayController.TurnOffLight(ELightType.PeterRoomMainLight);
                //    RelayController.TurnOnLight(ELightType.PeterRoomMainLight);
                //    //show events

                //    //send notification
            });
        }
    }
}
