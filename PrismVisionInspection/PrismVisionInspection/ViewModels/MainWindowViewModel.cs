using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using PrismVisionInspection.Core;
using PrismVisionInspection.Services;
using System;

namespace PrismVisionInspection.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        string _cameraStatus;
        public string CameraStatus
        {
            get => _cameraStatus;
            set => SetProperty(ref _cameraStatus, value);
        }
        public DelegateCommand<object> ChangePageCommand { get; set; }
        public MainWindowViewModel(IRegionManager regionManager, ICamera camera)
        {
            ChangePageCommand = new((arg) =>
            {
                regionManager.RequestNavigate(RegionNames.ContentRegion, arg.ToString());
            });


            camera.ConnectedEvent += (s, e) =>
            {
                CameraStatus = "연결완료";
            };
            camera.GrabStartedEvent += (s, e) =>
            {
                CameraStatus = "그랩 시작";
            };
            camera.GrabStoppedEvent += (s, e) =>
            {
                CameraStatus = "그랩 중지";
            };

            camera.DisconnectedEvent += (s, e) =>
            {
                CameraStatus = "연결해제";
            };

            camera.FrameGrabbedEvent += (s, e) =>
            {
                CameraStatus = "촬영완료" + DateTime.Now.ToString("ffff");
            };
        }
    }
}
