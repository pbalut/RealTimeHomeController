using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pbalut.RealTimeHomeController.Shared.Enums.Hubs;

namespace Pbalut.RealTimeHomeController.Shared.Enums.Attributes
{
    public class HubMethodAttribute : Attribute
    {
        public string ServerName { get; set; }
        public string ClientName { get; set; }
        public EHub Hub { get; }

        public HubMethodAttribute(string serverName, string clientName, EHub hub)
        {
            ServerName = serverName;
            ClientName = clientName;
            Hub = hub;
        }
    }
}
