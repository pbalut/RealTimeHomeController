using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Gpio;
using Pbalut.IoT.Commons;
using Pbalut.RealTimeHomeController.Shared.Enums;
using Pbalut.RealTimeHomeController.Shared.Enums.Extensions;
using IoT = Pbalut.IoT.Commons;

namespace Pbalut.RealTimeHomeController.HardwareController.HardwareControllers
{
    public static class RelayController
    {
        public static void InitializeRelayPins()
        {
            foreach (var light in EnumUtil.GetEnumValues<ELightType>())
            {
                if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Devices.Gpio.GpioPinValue"))
                {
                    Gpio.Controller.AddPin(light.GetGpioPin(), GpioPinValue.Low, GpioPinDriveMode.Output);
                }
            }
        }

        public static void TurnOnLight(ELightType light)
        {
            Gpio.Controller.Pin(light.GetGpioPin()).Write(GpioPinValue.High);
        }

        public static void TurnOffLight(ELightType light)
        {
            Gpio.Controller.Pin(light.GetGpioPin()).Write(GpioPinValue.Low);
        }
    }
}
