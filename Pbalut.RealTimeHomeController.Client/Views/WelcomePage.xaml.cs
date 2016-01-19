using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Pbalut.RealTimeHomeController.Client.Enums.AppData;
using Pbalut.RealTimeHomeController.Client.Exceptions.AppData;
using Pbalut.RealTimeHomeController.Client.Helpers;
using Pbalut.RealTimeHomeController.Client.ViewModels;

namespace Pbalut.RealTimeHomeController.Client.Views
{
    public sealed partial class WelcomePage : Page
    {
        public WelcomePage()
        {
            InitializeComponent();
        }

        private WelcomeViewModel ViewModel => new ViewModelLocator().Welcome;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel.OnNavigatedTo(e);
            base.OnNavigatedTo(e);
        }

        private async void WelcomePage_OnLoaded(object sender, RoutedEventArgs e)
        {
            try
            {
                ViewModel.UserName = AppDataHelper.Get<string>(EAppData.UserName);
            }
            catch (Exception ex) when (ex is NotFoundAppDataContainerException || ex is NotFoundAppDataKeyException)
            {
                ShowContentDialog();
            }
        }

        private async void ShowContentDialog()
        {
            UserContentDialog.Visibility = Visibility.Visible;
            var result = await UserContentDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                if (!string.IsNullOrEmpty(TextBoxName.Text))
                {
                    AppDataHelper.AddOrUpdate(EAppData.UserName, TextBoxName.Text);
                    UserContentDialog.Visibility = Visibility.Collapsed;
                }
                else
                {
                    ShowContentDialog();
                }
            }
        }
    }
}