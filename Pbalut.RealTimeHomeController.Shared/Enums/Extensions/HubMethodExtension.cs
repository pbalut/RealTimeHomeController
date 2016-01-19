using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pbalut.RealTimeHomeController.Shared.Enums.Attributes;
using Pbalut.RealTimeHomeController.Shared.Enums.Hubs;

namespace Pbalut.RealTimeHomeController.Shared.Enums.Extensions
{
    public static class HubMethodExtension
    {
        public static string GetServerName(this EHubMethod type)
        {
            return type.GetAttribute<HubMethodAttribute>().ServerName;
        }

        public static string GetClientName(this EHubMethod type)
        {
            return type.GetAttribute<HubMethodAttribute>().ClientName;
        }

        public static string GetHubName(this EHubMethod type)
        {
            return type.GetAttribute<HubMethodAttribute>().Hub.GetHubName();
        }
    }
}
