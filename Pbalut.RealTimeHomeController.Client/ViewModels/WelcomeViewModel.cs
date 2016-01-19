using Windows.UI.Xaml.Navigation;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Pbalut.RealTimeHomeController.Client.Interfaces;
using Pbalut.RealTimeHomeController.Client.ViewModels.Base;

namespace Pbalut.RealTimeHomeController.Client.ViewModels
{
    public class WelcomeViewModel : BaseViewModel, IViewModel
    {
        private string _userName;

        public WelcomeViewModel(INavigationService navigationService) :
            base(navigationService)
        {
            SetUserData();
        }

        public string UserName
        {
            get { return _userName; }
            set { Set(() => UserName, ref _userName, value); }
        }

        public RelayCommand GotoPage1Command { get; private set; }

        public void OnNavigatedTo(NavigationEventArgs parameters)
        {
            OnNavigatedTo();
        }

        private async void SetUserData()
        {
        }
    }
}