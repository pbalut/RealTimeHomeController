using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Pbalut.RealTimeHomeController.Shared.Enums
{
    public static class EnumUtil
    {
        public static TAttribute GetAttribute<TAttribute>(this Enum value)
            where TAttribute : Attribute
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            return type.GetRuntimeField(name)
                .GetCustomAttributes(false)
                .OfType<TAttribute>()
                .SingleOrDefault();
        }

        public static IEnumerable<T> GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        public static List<T> GetEnumValues<T>() where T : new()
        {
            T valueType = new T();
            return typeof(T).GetFields()
                .Select(fieldInfo => (T)fieldInfo.GetValue(valueType))
                .Distinct()
                .ToList();
        }
    }
}
