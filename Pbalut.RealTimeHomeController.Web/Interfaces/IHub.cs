using Pbalut.RealTimeHomeController.Shared.Enums.Groups;

namespace Pbalut.RealTimeHomeController.Web.Interfaces
{
    public interface IHub
    {
        void JoinGroup(EGroup group);
        void LeaveGroup(EGroup group);
    }
}
