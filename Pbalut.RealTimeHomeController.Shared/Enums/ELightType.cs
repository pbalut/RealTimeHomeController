using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pbalut.RealTimeHomeController.Shared.Enums.Attributes;

namespace Pbalut.RealTimeHomeController.Shared.Enums
{
    public enum ELightType
    {
        [LightType(5, "Peter room", "Bedside lamp")]
        PeterRoomMainLight,
        [LightType(18, "Peter room", "Desk lamp")]
        PeterRoomBedsideLamp,
        [LightType(19, "Living room", "Lamp")]
        LivingRoomLamp
    }
}
