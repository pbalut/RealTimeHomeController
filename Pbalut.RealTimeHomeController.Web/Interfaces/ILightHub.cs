using Pbalut.RealTimeHomeController.Shared.Models.Lights;

namespace Pbalut.RealTimeHomeController.Web.Interfaces
{
    public interface ILightHub
    {
        void LightChangeStateRequestToServer(LightClientRequest requestToServer);
        void LightChangeStateRequestToHardwareController(LightServerRequest requestToHardwareController);
        void LightInformAboutChangedState(LightServerResponse serverResponse);
        void LightInformAboutErrorOccuredWhileChangingState(LightChangeStateError error);
    }
}
