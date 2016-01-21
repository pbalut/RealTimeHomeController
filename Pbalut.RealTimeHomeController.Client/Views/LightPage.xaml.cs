using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Pbalut.RealTimeHomeController.Client.Listeners;
using Pbalut.RealTimeHomeController.Client.Senders;
using Pbalut.RealTimeHomeController.Client.ViewModels;
using Pbalut.RealTimeHomeController.Shared.Enums;
using Pbalut.RealTimeHomeController.Shared.Models;

namespace Pbalut.RealTimeHomeController.Client.Views
{
    public sealed partial class LightPage : Page
    {
        public LightPage()
        {
            InitializeComponent();
        }

        private LightViewModel ViewModel => new ViewModelLocator().Light;
        private LightListener LightListner { get; set; }
        private LightSender LightSender { get; set; }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel.OnNavigatedTo(e);
            base.OnNavigatedTo(e);

            LightListner = new LightListener();
            LightSender = new LightSender();
            LightListner.LightInformationReceived += (p, q) => { };
            //LightEngine.DoBlink += Blinker_DoBlink;
            //LightEngine.Start();
            //await LightListner.Init();
            await LightSender.Init();
        }
    }
}