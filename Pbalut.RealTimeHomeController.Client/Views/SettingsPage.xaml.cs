using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Pbalut.RealTimeHomeController.Client.ViewModels;

namespace Pbalut.RealTimeHomeController.Client.Views
{
    public sealed partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private SettingsViewModel ViewModel => new ViewModelLocator().Settings;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel.OnNavigatedTo(e);
            base.OnNavigatedTo(e);
        }
    }
}