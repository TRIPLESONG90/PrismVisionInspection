using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PrismVisionInspection.Services
{
    public class WebCam : ICamera
    {
        public event EventHandler ConnectedEvent;
        public event EventHandler DisconnectedEvent;
        public event EventHandler GrabStartedEvent;
        public event EventHandler GrabStoppedEvent;
        public event EventHandler<Mat> FrameGrabbedEvent;

        VideoCapture capture;
        public WebCam()
        {
            
        }
        public void Connect()
        {
            ConnectedEvent?.Invoke(this, null);
        }

        public void Disconnect()
        {
            DisconnectedEvent?.Invoke(this, null);
        }

        public void StartGrab()
        {
            capture = new VideoCapture(0);
            if (!capture.IsOpened())
                throw new Exception();

            GrabStartedEvent?.Invoke(this, null);
        }

        public void StopGrab()
        {
            capture.Dispose();
            GrabStoppedEvent?.Invoke(this, null);
        }

        public void SWTrigger()
        {
            Mat img = new Mat();
            capture.Read(img);
            FrameGrabbedEvent?.Invoke(this, img.Clone());
            img.Dispose();
        }
    }
}
