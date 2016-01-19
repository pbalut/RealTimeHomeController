using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Pbalut.RealTimeHomeController.HardwareController.Engines;
using Pbalut.RealTimeHomeController.HardwareController.HardwareControllers;
using Pbalut.RealTimeHomeController.HardwareController.Listeners;
using Pbalut.RealTimeHomeController.Shared.Enums;

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
            LightListner = new LightListener();
            LightListner.LightDataReceived += (p, q) =>
            {
                LightEngine.Field = q.State.ToString();
                var t = 2;
                //GPIO
                RelayController.TurnOffLight(ELightType.PeterRoomMainLight);
                RelayController.TurnOnLight(ELightType.PeterRoomMainLight);
                //show events

                //send notification

            };
            //LightEngine.DoBlink += Blinker_DoBlink;
            //LightEngine.Start();
            await LightListner.Init();
        }

        private async void Blinker_DoBlink(object sender, string e)
        {
            //lsOperator.Blink(e);
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {

            });
        }
    }
}
