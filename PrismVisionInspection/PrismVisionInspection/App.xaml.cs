using Prism.Ioc;
using Prism.Modularity;
using PrismVisionInspection.Modules.History;
using PrismVisionInspection.Modules.Inspection;
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
            containerRegistry.RegisterSingleton<VirtualCamera>(sp =>
            {
                return new VirtualCamera(@"C:\Users\exper\Pictures\Screenshots");
            });
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<HistoryModule>();
            moduleCatalog.AddModule<InspectionModule>();
        }
    }
}
