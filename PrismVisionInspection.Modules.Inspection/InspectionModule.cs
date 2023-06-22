using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismVisionInspection.Modules.Inspection.Views;

namespace PrismVisionInspection.Modules.Inspection
{
    public class InspectionModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Views.Inspection>();
        }
    }
}