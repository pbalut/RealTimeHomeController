using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pbalut.RealTimeHomeController.Shared.Enums.Attributes;

namespace Pbalut.RealTimeHomeController.Shared.Enums.Groups
{
    public enum EGroup
    {
        [Group("Server")]
        Server,
        [Group("Client")]
        Client
    }
}
