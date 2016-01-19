using System;
using System.Linq;
using Windows.Storage;
using Newtonsoft.Json;
using Pbalut.RealTimeHomeController.Client.Enums.AppData;
using Pbalut.RealTimeHomeController.Client.Exceptions.AppData;

namespace Pbalut.RealTimeHomeController.Client.Helpers
{
    public static class AppDataHelper
    {
        private static readonly ApplicationData ApplicationData = ApplicationData.Current;

        public static void AddOrUpdate(EAppData appData, object val)
        {
            var type = appData.DataAttributes().Type;
            var serialized = appData.DataAttributes().Serialized;
            var appDataContainer = GetMainAppDataContainer(type);

            //Create container if doesn't exist
            appDataContainer.CreateContainer(appData.DataAttributes().Container.ContainerAttributes().Name,
                ApplicationDataCreateDisposition.Always);

            //Set value
            var mainContainer = GetMainAppDataContainer(appData.DataAttributes().Type);
            mainContainer.Containers[appData.DataAttributes().Container.ContainerAttributes().Name].Values[
                appData.DataAttributes().Name] = serialized ? JsonConvert.SerializeObject(val) : val;

            if (type == EAppDataType.Roaming)
            {
                ApplicationData.SignalDataChanged();
            }
        }

        public static T Get<T>(EAppData appData)
        {
            var containerName = appData.DataAttributes().Container.ContainerAttributes().Name;
            var mainContainer = GetMainAppDataContainer(appData.DataAttributes().Type);

            if (mainContainer.Containers.ToList().All(i => i.Key != containerName))
                throw new NotFoundAppDataContainerException {Container = appData.DataAttributes().Container};

            if (mainContainer.Containers[appData.DataAttributes().Container.ContainerAttributes().Name].Values.
                All(i => i.Key != appData.DataAttributes().Name))
                throw new NotFoundAppDataContainerException {Container = appData.DataAttributes().Container};

            return appData.DataAttributes().Serialized
                ? JsonConvert.DeserializeObject<T>(
                    mainContainer.Containers[containerName].Values[appData.DataAttributes().Name].ToString())
                : Cast<T>(mainContainer.Containers[containerName].Values[appData.DataAttributes().Name]);
        }

        private static ApplicationDataContainer GetMainAppDataContainer(EAppDataType type)
        {
            switch (type)
            {
                case EAppDataType.Local:
                    return ApplicationData.LocalSettings;
                case EAppDataType.Roaming:
                    return ApplicationData.RoamingSettings;
                default:
                    throw new ArgumentException("Invalid application data type");
            }
        }

        private static T ConvertValue<T, TU>(TU value) where TU : IConvertible
        {
            return (T) Convert.ChangeType(value, typeof (T));
        }

        private static T Cast<T>(object obj) //where T : struct
        {
            return (T) obj; //as T;
        }
    }
}