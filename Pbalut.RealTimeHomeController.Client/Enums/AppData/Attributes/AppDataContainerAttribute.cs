using System;

namespace Pbalut.RealTimeHomeController.Client.Enums.AppData.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class AppDataContainerAttribute : Attribute
    {
        public AppDataContainerAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}