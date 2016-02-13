using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Pbalut.RealTimeHomeController.Client.HubProxy;
using Pbalut.RealTimeHomeController.Client.ViewModels;

namespace Pbalut.RealTimeHomeController.Client.Views
{
    public sealed partial class LightPage : Page
    {
        private LightViewModel ViewModel => new ViewModelLocator().Light;

        public LightPage()
        {
            InitializeComponent();
        }

        //private LightListener LightListner { get; set; }
        //private LightSender LightSender { get; set; }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel.OnNavigatedTo(e);
            base.OnNavigatedTo(e);


            var lightHubProxy = new LightHubProxy();
            await lightHubProxy.Start();


            //LightListner = new LightListener();
            //LightSender = new LightSender();
            //LightListner.LightInformationReceived += (p, q) => { };
            //LightEngine.DoBlink += Blinker_DoBlink;
            //LightEngine.Start();
            //await LightListner.Init();
            //await LightSender.Init();
        }
    }
}