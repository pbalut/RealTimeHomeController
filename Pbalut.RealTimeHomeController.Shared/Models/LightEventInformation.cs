﻿using System;
using Pbalut.RealTimeHomeController.Shared.Enums;

namespace Pbalut.RealTimeHomeController.Shared.Models
{
    public class LightEventInformation
    {
        public DateTime DateTime { get; set; }
        public string ServerName { get; set; }
        public string UserName { get; set; }
        public ELightState StateFrom { get; set; }
        public ELightState StateTo { get; set; }
        public ELightType Type { get; set; }
        public EEventSource Source { get; set; }
    }
}
