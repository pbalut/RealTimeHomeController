using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pbalut.RealTimeHomeController.Shared.Enums;

namespace Pbalut.RealTimeHomeController.Shared.Models
{
    public class Light : BaseModel
    {
        public ELightState State { get; set; }
        public ELightType Type { get; set; }
    }
}
