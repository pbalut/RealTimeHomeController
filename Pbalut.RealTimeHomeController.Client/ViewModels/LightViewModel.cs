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
            //GotoPage1Command = new RelayCommand(() => _navigationService.NavigateTo("Page1"));
        }

        public Uri IconTest
        {
            get { return new Uri("ms-appx:///Assets/Icons/Lights/appbar.lamp.png"); }
            set
            {
                if (Set(ref _iconTest, value))
                {
                    RaisePropertyChanged(() => IconTest);
                }
            }
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
                        Icon = IconHelper.GetLightIconUri(light)
                    }).ToList());
        }
    }
}