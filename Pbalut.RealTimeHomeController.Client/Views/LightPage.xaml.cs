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

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel.OnNavigatedTo(e);
            base.OnNavigatedTo(e);

            var lightHubProxy = new LightHubProxy();
            await lightHubProxy.Start();
        }
    }
}