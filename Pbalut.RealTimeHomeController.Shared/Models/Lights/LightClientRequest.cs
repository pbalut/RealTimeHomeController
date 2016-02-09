using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pbalut.RealTimeHomeController.Shared.Enums;

namespace Pbalut.RealTimeHomeController.Shared.Models.Lights
{
    public class LightClientRequest
    {
        public ELightState State { get; set; }
        public ELightType Type { get; set; }
        public string UserName { get; set; }
        public EEventSource Source { get; set; }
    }
}
