using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pbalut.RealTimeHomeController.Shared.Enums.Attributes;

namespace Pbalut.RealTimeHomeController.Shared.Enums.Hubs
{
    public enum EHubMethod
    {
        [HubMethod("ChangeState", "LightChangeState", EHub.Light)]
        LightChangeState,
        [HubMethod("SendInformation", "LightSendInformation", EHub.Light)]
        LightSendInformation
    }
}
