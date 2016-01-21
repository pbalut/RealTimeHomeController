using Pbalut.RealTimeHomeController.Shared.Enums.Attributes;
using Pbalut.RealTimeHomeController.Shared.Enums.Groups;

namespace Pbalut.RealTimeHomeController.Shared.Enums.Extensions
{
    public static class GroupExtension
    {
        public static string GetGroupName(this EGroup type)
        {
            return type.GetAttribute<GroupAttribute>().Name;
        }
    }
}
