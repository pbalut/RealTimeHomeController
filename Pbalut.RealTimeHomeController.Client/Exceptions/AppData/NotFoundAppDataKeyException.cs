using System;
using Pbalut.RealTimeHomeController.Client.Enums.AppData;

namespace Pbalut.RealTimeHomeController.Client.Exceptions.AppData
{
    public class NotFoundAppDataKeyException : Exception
    {
        public EAppDataContainer Container { get; set; }
        public EAppDataType Type { get; set; }
    }
}