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
        [HubMethod("JoinGroup", "LightJoinGroup", EHub.Light)]
        LightJoinGroup,
        [HubMethod("LeaveGroup", "LightLeaveGroup", EHub.Light)]
        LightLeaveGroup,
        [HubMethod("ChangeState", "LightChangeState", EHub.Light)]
        LightChangeState,
        [HubMethod("InformAboutChangedState", "LightInformAboutChangedState", EHub.Light)]
        LightInformAboutChangedState
    }
}
