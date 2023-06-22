using Prism.Ioc;
using Prism.Modularity;
using PrismVisionInspection.Modules.ModuleName;
using PrismVisionInspection.Services;
using PrismVisionInspection.Services.Interfaces;
using PrismVisionInspection.Views;
using System.Windows;

namespace PrismVisionInspection
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IMessageService, MessageService>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ModuleNameModule>();
        }
    }
}
