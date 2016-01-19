using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pbalut.RealTimeHomeController.Shared.Enums.Attributes;
using Pbalut.RealTimeHomeController.Shared.Enums.Hubs;

namespace Pbalut.RealTimeHomeController.Shared.Enums.Extensions
{
    public static class HubExtension
    {
        public static string GetHubName(this EHub type)
        {
            return type.GetAttribute<HubAttribute>().Name;
        }
    }
}
