using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Pbalut.RealTimeHomeController.Client.Enums.AppData;
using Pbalut.RealTimeHomeController.Client.Helpers;
using Pbalut.RealTimeHomeController.Client.ViewModels.Base;
using Pbalut.RealTimeHomeController.Shared.Enums;
using Pbalut.RealTimeHomeController.Shared.Models;

namespace Pbalut.RealTimeHomeController.Client.Models
{
    public class RelayDevice : ViewModelBase
    {
        private bool _isOn;

        public string Name { get; set; }
        public string Description { get; set; }
        public Uri Icon { get; set; }
        public ELightType Type { get; set; }
        public bool IsOn
        {
            get { return _isOn; }
            set
            {
                if (Set(ref _isOn, value))
                {
                    Messenger.Default.Send(new NotificationMessage<Light>(new Light()
                    {
                        //TODO
                        //User = AppDataHelper.Get<string>(EAppData.UserName),
                        State = _isOn ? ELightState.TurnOn : ELightState.TurnOff,
                        Type = this.Type
                    }, "Select"));
                    RaisePropertyChanged(() => IsOn);
                }
            }
        }
    }
}