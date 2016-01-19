using Pbalut.RealTimeHomeController.Client.Enums.AppData.Attributes;

namespace Pbalut.RealTimeHomeController.Client.Enums.AppData
{
    public enum EAppData
    {
        [AppData("ServerUrl", EAppDataContainer.Server, EAppDataType.Local)] ServerUrl,
        [AppData("UserName", EAppDataContainer.UserData, EAppDataType.Local)] UserName
    }
}