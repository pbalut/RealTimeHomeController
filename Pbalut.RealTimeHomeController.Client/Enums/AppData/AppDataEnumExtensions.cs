using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Pbalut.RealTimeHomeController.Client.Enums.AppData.Attributes;

namespace Pbalut.RealTimeHomeController.Client.Enums.AppData
{
    public static class AppDataEnumExtensions
    {
        public static AppDataAttribute DataAttributes(this Enum aEnumValue)
        {
            var type = aEnumValue.GetType();
            var fieldInfo = type.GetRuntimeField(aEnumValue.ToString());
            var attributes = fieldInfo.GetCustomAttributes(typeof (AppDataAttribute), false) as AppDataAttribute[];
            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0];
            }
            return null;
        }

        public static AppDataContainerAttribute ContainerAttributes(this Enum aEnumValue)
        {
            var type = aEnumValue.GetType();
            var fieldInfo = type.GetRuntimeField(aEnumValue.ToString());
            var attributes =
                fieldInfo.GetCustomAttributes(typeof (AppDataContainerAttribute), false) as AppDataContainerAttribute[];
            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0];
            }
            return null;
        }

        public static IEnumerable<T> GetAllItems<T>(this Enum value)
        {
            return from object item in Enum.GetValues(typeof (T)) select (T) item;
        }
    }
}