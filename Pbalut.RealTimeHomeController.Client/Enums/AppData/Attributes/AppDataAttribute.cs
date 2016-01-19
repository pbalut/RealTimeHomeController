using System;

namespace Pbalut.RealTimeHomeController.Client.Enums.AppData.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class AppDataAttribute : Attribute
    {
        public AppDataAttribute(string name, EAppDataContainer container, EAppDataType type, bool serialized = false)
        {
            Name = name;
            Container = container;
            Type = type;
            Serialized = serialized;
        }

        public string Name { get; }
        public EAppDataContainer Container { get; set; }
        public EAppDataType Type { get; set; }
        public bool Serialized { get; set; }
    }
}