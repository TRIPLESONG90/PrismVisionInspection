using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismVisionInspection.Modules.History.Views;

namespace PrismVisionInspection.Modules.History
{
    public class HistoryModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Views.History>();
        }
    }
}