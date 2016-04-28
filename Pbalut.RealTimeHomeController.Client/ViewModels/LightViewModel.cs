using System;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Core;
using Windows.UI.Xaml.Navigation;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using Pbalut.RealTimeHomeController.Client.Helpers;
using Pbalut.RealTimeHomeController.Client.Interfaces;
using Pbalut.RealTimeHomeController.Client.Models;
using Pbalut.RealTimeHomeController.Client.ViewModels.Base;
using Pbalut.RealTimeHomeController.Shared.Enums;
using Pbalut.RealTimeHomeController.Shared.Enums.Extensions;
using Pbalut.RealTimeHomeController.Shared.Models.Lights;

namespace Pbalut.RealTimeHomeController.Client.ViewModels
{
    public class LightViewModel : BaseViewModel, IViewModel
    {
        private ObservableCollection<RelayDevice> _relayDevices;

        public LightViewModel(INavigationService navigationService) :
            base(navigationService)
        {
            SetRelayDevices();
            Messenger.Default.Register<NotificationMessage<LightServerResponse>>(this,  message =>
            {
                SetStateFromServerResponse(message.Content);
            });
            Messenger.Default.Register<NotificationMessage<LightChangeStateError>>(this, message =>
            {
                SetStateFromServerResponse(message.Content);
            });
        }

        public ObservableCollection<RelayDevice> RelayDevices
        {
            get { return _relayDevices; }
            set
            {
                if (Set(ref _relayDevices, value))
                {
                    RaisePropertyChanged(() => RelayDevices);
                }
            }
        }

        public void OnNavigatedTo(NavigationEventArgs parameters)
        {
            OnNavigatedTo();
        }

        private void SetRelayDevices()
        {
            RelayDevices =
                new ObservableCollection<RelayDevice>(
                    EnumUtil.GetEnumValues<ELightType>().Select(light => new RelayDevice
                    {
                        Name = light.GetName(),
                        Description = light.GetDescription(),
                        Icon = IconHelper.GetLightIconUri(light),
                        Type = light
                    }).ToList());
        }

        private async void SetStateFromServerResponse(LightServerResponse response)
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                () =>
                {
                    RelayDevices.Single(i => i.Type == response.Type).IsOn = response.StateTo == ELightState.TurnOn;
                }
            );
        }

        private async void ShowError(LightChangeStateError response)
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                async () =>
                {
                    var dialog = new Windows.UI.Popups.MessageDialog("Error");
                    await dialog.ShowAsync();
                }
            );
        }
    }
}