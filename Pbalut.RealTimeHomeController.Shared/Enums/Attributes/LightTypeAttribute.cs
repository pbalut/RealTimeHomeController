using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pbalut.RealTimeHomeController.Shared.Enums.Attributes
{
    public class LightTypeAttribute : Attribute
    {
        public int GpioPin { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public LightTypeAttribute(int gpioPin, string name, string description)
        {
            GpioPin = gpioPin;
            Name = name;
            Description = description;
        }
    }
}
