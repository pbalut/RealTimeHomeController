using Pbalut.RealTimeHomeController.Shared.Enums;

namespace Pbalut.RealTimeHomeController.Shared.Models.Lights
{
    public class LightServerRequest
    {
        public ELightState State { get; set; }
        public ELightType Type { get; set; }
        public string UserName { get; set; }
        public EEventSource Source { get; set; }

        public override string ToString() => State.ToString();
    }
}
