using System;
using Pbalut.RealTimeHomeController.Client.Enums.AppData;

namespace Pbalut.RealTimeHomeController.Client.Exceptions.AppData
{
    public class NotFoundAppDataContainerException : Exception
    {
        public EAppDataContainer Container { get; set; }
    }
}