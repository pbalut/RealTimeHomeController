using System.Linq;
using Windows.UI.Xaml.Controls;
using Pbalut.RealTimeHomeController.Client.Common;
using Pbalut.RealTimeHomeController.Client.Views;

namespace Pbalut.RealTimeHomeController.Client
{
    public sealed partial class Shell : UserControl
    {
        public Shell()
        {
            InitializeComponent();

            var vm = new ShellViewModel();
            vm.MenuItems.Add(new MenuItem {Icon = "Home", Title = "Welcome", PageType = typeof (WelcomePage)});
            vm.MenuItems.Add(new MenuItem {Icon = "DockLeft", Title = "Light", PageType = typeof (LightPage)});
            vm.MenuItems.Add(new MenuItem {Icon = "Setting", Title = "Settings", PageType = typeof (SettingsPage)});
            // select the first menu item
            vm.SelectedMenuItem = vm.MenuItems.First();

            ViewModel = vm;
        }

        public ShellViewModel ViewModel { get; private set; }

        public Frame RootFrame => Frame;
    }
}