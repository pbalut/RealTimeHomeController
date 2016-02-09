using Pbalut.RealTimeHomeController.Shared.Models.Lights;

namespace Pbalut.RealTimeHomeController.Web.Interfaces
{
    public interface ILightHub
    {
        void LightChangeStateRequestToServer(LightClientRequest requestToServer);
        void LightInformAboutChangedState(LightServerResponse serverResponse);
        void LightInformAboutErrorOccuredWhileChangingState(LightChangeStateError error);
    }
}
