using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using NLog;
using Pbalut.RealTimeHomeController.Shared.Enums.Extensions;
using Pbalut.RealTimeHomeController.Shared.Enums.Groups;
using Pbalut.RealTimeHomeController.Shared.Models.Lights;
using Pbalut.RealTimeHomeController.Web.Interfaces;

namespace Pbalut.RealTimeHomeController.Web.Hubs
{
    public class LightHub : Hub<ILightHub>, IHub
    {
        private Logger  Logger => LogManager.GetLogger(GetType().FullName); 

        public async Task JoinGroup(EGroup group)
        {
            Logger.Log(LogLevel.Trace, $"Join group | Group name: {group.GetGroupName()}, connection id: {Context.ConnectionId}");
            await Groups.Add(Context.ConnectionId, group.GetGroupName());
        }

        public async Task LeaveGroup(EGroup group)
        {
            Logger.Log(LogLevel.Trace, $"Leave group | Group name: {group.GetGroupName()}, connection id: {Context.ConnectionId}");
            await Groups.Remove(Context.ConnectionId, group.GetGroupName());
        }

        public void ChangeStateRequestToServer(LightClientRequest requestFromClient)
        {
            try
            {
                Logger.Log(LogLevel.Trace, $"ChangeStateRequestToServer | {requestFromClient}");
                Clients.Group(EGroup.Server.GetGroupName()).LightChangeStateRequestToHardwareController(new LightServerRequest() { State = requestFromClient.State});
            }
            catch (Exception ex)
            {
                Logger.Log(LogLevel.Error, ex);
            }
        }

        public void InformAboutChangedState(LightServerResponse serverResponse)
        {
            try
            {
                Logger.Log(LogLevel.Trace, $"InformAboutChangedState | {serverResponse}");
                Clients.Group(EGroup.Client.GetGroupName()).LightInformAboutChangedState(serverResponse);
            }
            catch (Exception ex)
            {
                Logger.Log(LogLevel.Error, ex);
            }
        }

        public void InformAboutErrorOccuredWhileChangingState(LightChangeStateError error)
        {
            try
            {
                Logger.Log(LogLevel.Trace, $"InformAboutErrorOccuredWhileChangingState | {error}");
                Clients.Group(EGroup.Client.GetGroupName()).LightInformAboutErrorOccuredWhileChangingState(error);
            }
            catch (Exception ex)
            {
                Logger.Log(LogLevel.Error, ex);
            }
        }
    }
}