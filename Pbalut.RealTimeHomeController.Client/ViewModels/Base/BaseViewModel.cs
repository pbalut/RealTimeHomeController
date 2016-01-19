using System;
using Windows.UI.Popups;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using Pbalut.RealTimeHomeController.Client.Enums;

namespace Pbalut.RealTimeHomeController.Client.ViewModels.Base
{
    public class BaseViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public BaseViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void OnNavigatedTo()
        {
        }

        public async void ShowDialog(string content, EDialogType dialogType)
        {
            var dialog = new MessageDialog(content);

            switch (dialogType)
            {
                case EDialogType.Success:
                    dialog.Title = "Success";
                    break;
                case EDialogType.Error:
                    dialog.Title = "Error";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(dialogType), dialogType, null);
            }
            await dialog.ShowAsync();
        }
    }
}