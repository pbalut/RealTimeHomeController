using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Gpio;

namespace Pbalut.IoT.Commons
{
    public class Gpio
    {
        private static Gpio _controller;
        private readonly Dictionary<int, GpioPin> _pins = new Dictionary<int, GpioPin>();
        private readonly GpioController _gpioController;
        public static Gpio Controller => _controller ?? (_controller = new Gpio());

        public Gpio()
        {
            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Devices.Gpio.GpioController"))
            {
                _gpioController = GpioController.GetDefault();
            }
            else
            {
                throw new NotSupportedException("Device doesn't support GPIO");
            }
        }

        public GpioPin Pin(int pinNumber)
        {
            if (!_pins.ContainsKey(pinNumber))
            {
                throw new KeyNotFoundException($"Pin with numer {pinNumber} doesn't exist");
            }
            return _pins[pinNumber];
        }

        public void AddPin(int pinNumber, GpioPinValue value, GpioPinDriveMode mode)
        {
            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Devices.Gpio.GpioController"))
            {
                var gpioPin = _gpioController.OpenPin(pinNumber, GpioSharingMode.Exclusive);
                gpioPin.Write(value);
                gpioPin.SetDriveMode(mode);
                _pins.Add(pinNumber, gpioPin);
            }
            else
            {
                throw new NotSupportedException("Device doesn't support GPIO");
            }
        }

        public void RemovePin(int pinNumber)
        {
            if (!_pins.ContainsKey(pinNumber))
            {
                throw new KeyNotFoundException($"Pin with numer {pinNumber} doesn't exist");
            }
            _pins.Remove(pinNumber);
        }
    }
}
