using System.Diagnostics.CodeAnalysis;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using Pbalut.RealTimeHomeController.Client.Common;

namespace Pbalut.RealTimeHomeController.Client.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<INavigationService, NavigationService>();
            }
            else
            {
                if (!SimpleIoc.Default.IsRegistered<INavigationService>())
                {
                    var navigationService = CreateNavigationService();
                    SimpleIoc.Default.Register(() => navigationService);
                }
            }

            SimpleIoc.Default.Register<WelcomeViewModel>();
            SimpleIoc.Default.Register<LightViewModel>();
            SimpleIoc.Default.Register<SettingsViewModel>();
        }

        [SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public WelcomeViewModel Welcome => ServiceLocator.Current.GetInstance<WelcomeViewModel>();

        public LightViewModel Light => ServiceLocator.Current.GetInstance<LightViewModel>();
        public SettingsViewModel Settings => ServiceLocator.Current.GetInstance<SettingsViewModel>();

        private INavigationService CreateNavigationService()
        {
            var navigationService = new NavigationServiceUwp();
            return navigationService;
        }
    }
}