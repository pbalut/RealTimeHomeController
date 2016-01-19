using System;
using Windows.UI.Xaml.Navigation;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Pbalut.RealTimeHomeController.Client.Enums;
using Pbalut.RealTimeHomeController.Client.Enums.AppData;
using Pbalut.RealTimeHomeController.Client.Exceptions.AppData;
using Pbalut.RealTimeHomeController.Client.Helpers;
using Pbalut.RealTimeHomeController.Client.Interfaces;
using Pbalut.RealTimeHomeController.Client.ViewModels.Base;
using Pbalut.RealTimeHomeController.Shared.AppData;

namespace Pbalut.RealTimeHomeController.Client.ViewModels
{
    public class SettingsViewModel : BaseViewModel, IViewModel
    {
        private RelayCommand _saveSettingsCommand;
        private string _serverAddress;
        private string _userName;

        public SettingsViewModel(INavigationService navigationService) :
            base(navigationService)
        {
            SetDefaultSettings();
        }

        public RelayCommand SaveSettingsCommand
        {
            get
            {
                return _saveSettingsCommand
                       ?? (_saveSettingsCommand = new RelayCommand(
                           () =>
                           {
                               try
                               {
                                   AppDataHelper.AddOrUpdate(EAppData.UserName, UserName);
                                   AppDataHelper.AddOrUpdate(EAppData.ServerUrl, ServerAddress);
                                   ShowDialog("Successfully saved settings", EDialogType.Success);
                               }
                               catch (Exception ex)
                               {
                                   ShowDialog("Error occurred during save settings", EDialogType.Error);
                               }
                           }));
            }
        }

        public string ServerAddress
        {
            get { return _serverAddress; }
            set
            {
                if (Set(ref _serverAddress, value))
                {
                    RaisePropertyChanged(() => ServerAddress);
                }
            }
        }

        public string UserName
        {
            get { return _userName; }
            set
            {
                if (Set(ref _userName, value))
                {
                    RaisePropertyChanged(() => UserName);
                }
            }
        }

        public void OnNavigatedTo(NavigationEventArgs parameters)
        {
            OnNavigatedTo();
        }

        private void SetDefaultSettings()
        {
            try
            {
                UserName = AppDataHelper.Get<string>(EAppData.UserName);
                ServerAddress = AppDataHelper.Get<string>(EAppData.ServerUrl);
            }
            catch (Exception ex) when (ex is NotFoundAppDataContainerException || ex is NotFoundAppDataKeyException)
            {
                ServerAddress = EndPoint.HubUrl;
            }
        }
    }
}