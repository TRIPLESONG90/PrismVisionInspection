using OpenCvSharp;
using OpenCvSharp.WpfExtensions;
using Prism.Commands;
using Prism.Mvvm;
using PrismVisionInspection.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PrismVisionInspection.Modules.Inspection.ViewModels
{
    public class InspectionViewModel : BindableBase
    {
        BitmapSource _image;
        public BitmapSource Image
        {
            get => _image;
            set => SetProperty(ref _image, value);
        }

        int _okCnt;
        public int OKCnt
        {
            get => _okCnt;
            set=>SetProperty(ref _okCnt, value);
        }

        int _ngCnt;
        public int NGCnt
        {
            get => _ngCnt;
            set => SetProperty(ref _ngCnt, value);
        }

        public DelegateCommand StartCommand { get; set; }
        public DelegateCommand StopCommand { get; set; }
        public DelegateCommand TriggerCommand { get; set; }

        public InspectionViewModel(VirtualCamera camera)
        {
            StartCommand = new(() =>
            {
                camera.Connect();
                camera.StartGrab();
            });

            TriggerCommand = new(() =>
            {
                camera.SWTrigger();
            });

            StopCommand = new(() =>
            {
                camera.StopGrab();
                camera.Disconnect();
            });

            camera.FrameGrabbedEvent += (s, e) =>
            {
                var gray = e.CvtColor(ColorConversionCodes.BGR2GRAY);
                var threshold = gray.Threshold(128, 255, ThresholdTypes.Binary);
                Image = BitmapSourceConverter.ToBitmapSource(threshold);
            };
            
        }
    }
}
