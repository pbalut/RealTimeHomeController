using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pbalut.RealTimeHomeController.Shared.Models;

namespace Pbalut.RealTimeHomeController.Web.Interfaces
{
    public interface ILightHub
    {
        void LightChangeState(Light light);
        void LightSendInformation(LightEventInformation lightEventInformation);
    }
}
