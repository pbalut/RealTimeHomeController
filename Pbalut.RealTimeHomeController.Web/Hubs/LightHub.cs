using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Pbalut.RealTimeHomeController.Shared.Enums;
using Pbalut.RealTimeHomeController.Shared.Models;
using Pbalut.RealTimeHomeController.Web.Interfaces;

namespace Pbalut.RealTimeHomeController.Web.Hubs
{
    public class LightHub : Hub<ILightHub>
    {
        public void ChangeState(string user, string lightState, string lightType)
        {
            try
            {
                var light = new Light()
                {
                    User = user,
                    State = EnumUtil.ParseEnum<ELightState>(lightState),
                    Type = EnumUtil.ParseEnum<ELightType>(lightType)
                };
                Clients.All.LightChangeState(light);
            }
            catch (Exception ex)
            {
                //TODO
            }
        }

        public void ChangeState(Light light)
        {
            try
            {
                Clients.All.LightChangeState(light);
            }
            catch (Exception ex)
            {
                //TODO
            }
        }

        public void SendInformation(LightEventInformation lightEventInformation)
        {
            try
            {
                Clients.All.LightSendInformation(lightEventInformation);
            }
            catch (Exception ex)
            {
                //TODO
            }
        }
    }
}