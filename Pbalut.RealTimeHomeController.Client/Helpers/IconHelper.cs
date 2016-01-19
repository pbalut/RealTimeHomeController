using System;
using Pbalut.RealTimeHomeController.Shared.Enums;

namespace Pbalut.RealTimeHomeController.Client.Helpers
{
    public static class IconHelper
    {
        public static Uri GetLightIconUri(ELightType lightType)
        {
            switch (lightType)
            {
                case ELightType.PeterRoomMainLight:
                    return new Uri("ms-appx:///Assets/Icons/Lights/appbar.lamp.variant.png");
                case ELightType.PeterRoomBedsideLamp:
                    return new Uri("ms-appx:///Assets/Icons/Lights/appbar.lamp.png");
                case ELightType.LivingRoomLamp:
                    return new Uri("ms-appx:///Assets/Icons/Lights/appbar.lamp.desk.png");
                default:
                    throw new ArgumentOutOfRangeException(nameof(lightType), lightType, null);
            }
        }
    }
}