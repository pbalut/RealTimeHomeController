using Pbalut.RealTimeHomeController.Shared.Enums.Attributes;

namespace Pbalut.RealTimeHomeController.Shared.Enums.Hubs
{
    public enum EHubMethod
    {
        [HubMethod("JoinGroup", "LightJoinGroup", EHub.Light)]
        LightJoinGroup,
        [HubMethod("LeaveGroup", "LightLeaveGroup", EHub.Light)]
        LightLeaveGroup,

        [HubMethod("ChangeStateRequestToServer", "LightChangeStateRequestToServer", EHub.Light)]
        LightChangeStateClientRequest,
        [HubMethod("ChangeStateServerRequest", "LightChangeStateRequestToHardwareController", EHub.Light)]
        LightChangeStateServerRequest,

        [HubMethod("InformAboutChangedState", "LightInformAboutChangedState", EHub.Light)]
        LightInformAboutChangedState,
        [HubMethod("InformAboutErrorOccuredWhileChangingState", "LightInformAboutErrorOccuredWhileChangingState", EHub.Light)]
        LightInformAboutErrorOccuredWhileChangingState
    }
}
