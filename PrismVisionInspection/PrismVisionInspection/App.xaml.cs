using Prism.Ioc;
using Prism.Modularity;
using PrismVisionInspection.Modules.History;
using PrismVisionInspection.Modules.Inspection;
using PrismVisionInspection.Services;
using PrismVisionInspection.Services.Interfaces;
using PrismVisionInspection.Views;
using System.Net.Http;
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
            containerRegistry.RegisterSingleton<ICamera>(sp =>
            {
                return new WebCam();
            });
            containerRegistry.RegisterSingleton<HttpClient>(sp =>
            {
                return new HttpClient()
                {
                    BaseAddress = new System.Uri("http://triplesong90.iptime.org:800")
                };
            });
            containerRegistry.RegisterSingleton<ObjectDetection>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<HistoryModule>();
            moduleCatalog.AddModule<InspectionModule>();
        }
    }
}
