namespace Pbalut.RealTimeHomeController.Shared.Models.Lights
{
    public class LightChangeStateError : LightServerResponse
    {
        public string ErrorMessage { get; set; }
        public string UserConnectionId { get; set; }
    }
}
