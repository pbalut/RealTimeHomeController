using System;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml.Navigation;
using GalaSoft.MvvmLight.Views;
using Pbalut.RealTimeHomeController.Client.Helpers;
using Pbalut.RealTimeHomeController.Client.Interfaces;
using Pbalut.RealTimeHomeController.Client.Models;
using Pbalut.RealTimeHomeController.Client.ViewModels.Base;
using Pbalut.RealTimeHomeController.Shared.Enums;
using Pbalut.RealTimeHomeController.Shared.Enums.Extensions;

namespace Pbalut.RealTimeHomeController.Client.ViewModels
{
    public class LightViewModel : BaseViewModel, IViewModel
    {
        private Uri _iconTest;
        private ObservableCollection<RelayDevice> _relayDevices;

        public LightViewModel(INavigationService navigationService) :
            base(navigationService)
        {
            SetRelayDevices();
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
    }
}