using System.Threading.Tasks;
using Pbalut.RealTimeHomeController.Shared.Enums.Groups;

namespace Pbalut.RealTimeHomeController.Web.Interfaces
{
    public interface IHub
    {
        Task JoinGroup(EGroup group);
        Task LeaveGroup(EGroup group);
    }
}
