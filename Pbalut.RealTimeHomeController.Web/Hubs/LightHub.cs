using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Pbalut.RealTimeHomeController.Shared.Enums.Extensions;
using Pbalut.RealTimeHomeController.Shared.Enums.Groups;
using Pbalut.RealTimeHomeController.Shared.Models.Lights;
using Pbalut.RealTimeHomeController.Web.Interfaces;

namespace Pbalut.RealTimeHomeController.Web.Hubs
{
    public class LightHub : Hub<ILightHub>, IHub
    {
        public async Task JoinGroup(EGroup group)
        {
            await Groups.Add(Context.ConnectionId, group.GetGroupName());
        }

        public async Task LeaveGroup(EGroup group)
        {
            await Groups.Remove(Context.ConnectionId, group.GetGroupName());
        }

        public void ChangeState(LightClientRequest requestFromClient)
        {
            try
            {
                Clients.Group(EGroup.Server.GetGroupName()).LightChangeStateRequestToServer(requestFromClient);
                Clients.Group(EGroup.Client.GetGroupName()).LightInformAboutChangedState(new LightServerResponse() {ServerName = "d"});
            }
            catch (Exception ex)
            {
                //TODO
            }
        }

        public void InformAboutChangedState(LightServerResponse serverResponse)
        {
            try
            {
                Clients.Group(EGroup.Client.GetGroupName()).LightInformAboutChangedState(serverResponse);
            }
            catch (Exception ex)
            {
                //TODO
            }
        }

        public void InformAboutErrorOccuredWhileChangingState(LightChangeStateError error)
        {
            try
            {
                Clients.Group(EGroup.Client.GetGroupName()).LightInformAboutErrorOccuredWhileChangingState(error);
            }
            catch (Exception ex)
            {
                //TODO
            }
        }
    }
}