using Prism.Regions;
using PrismVisionInspection.Core;
using System.Windows;

namespace PrismVisionInspection.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IRegionManager regionManager)
        {
            InitializeComponent();
            this.Loaded += (s, e) =>
            {
                regionManager.RequestNavigate(RegionNames.ContentRegion, "Inspection");
            };
        }
    }
}
