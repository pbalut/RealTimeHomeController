using System;
using Microsoft.AspNet.SignalR;
using Pbalut.RealTimeHomeController.Shared.Enums;
using Pbalut.RealTimeHomeController.Shared.Enums.Extensions;
using Pbalut.RealTimeHomeController.Shared.Enums.Groups;
using Pbalut.RealTimeHomeController.Shared.Models;
using Pbalut.RealTimeHomeController.Web.Interfaces;

namespace Pbalut.RealTimeHomeController.Web.Hubs
{
    public class LightHub : Hub<ILightHub>, IHub
    {
        public void JoinGroup(EGroup group)
        {
            Groups.Add(Context.ConnectionId, group.GetGroupName());
        }

        public void LeaveGroup(EGroup group)
        {
            Groups.Remove(Context.ConnectionId, group.GetGroupName());
        }

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