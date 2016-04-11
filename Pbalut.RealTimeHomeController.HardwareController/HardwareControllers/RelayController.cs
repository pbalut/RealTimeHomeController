using System.Linq;
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
            foreach (var light in EnumUtil.GetEnumValues<ELightType>().Where(light => Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Devices.Gpio.GpioPinValue")))
            {
                Gpio.Controller.AddPin(light.GetGpioPin(), GpioPinValue.Low, GpioPinDriveMode.Output);
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

        public static void ChangeLightState(ELightType light, ELightState state)
        {
            Gpio.Controller.Pin(light.GetGpioPin()).Write(state == ELightState.TurnOn ? GpioPinValue.High : GpioPinValue.Low);
        }
    }
}
