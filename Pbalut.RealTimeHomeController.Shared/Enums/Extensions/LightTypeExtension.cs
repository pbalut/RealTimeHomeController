using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pbalut.RealTimeHomeController.Shared.Enums.Attributes;

namespace Pbalut.RealTimeHomeController.Shared.Enums.Extensions
{
    public static class LightTypeExtension
    {
        public static int GetGpioPin(this ELightType type)
        {
            return type.GetAttribute<LightTypeAttribute>().GpioPin;
        }

        public static string GetName(this ELightType type)
        {
            return type.GetAttribute<LightTypeAttribute>().Name;
        }

        public static string GetDescription(this ELightType type)
        {
            return type.GetAttribute<LightTypeAttribute>().Description;
        }
    }
}
