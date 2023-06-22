using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using OpenCvSharp;

namespace PrismVisionInspection.Services
{
    public class VirtualCamera
    {
        List<string> _files;
        public event EventHandler ConnectedEvent;
        public event EventHandler DisconnectedEvent;
        public event EventHandler GrabStartedEvent;
        public event EventHandler GrabStoppedEvent;

        public event EventHandler<Mat> FrameGrabbedEvent;
        public VirtualCamera(string dirPath)
        {
            _files = Directory.GetFiles(dirPath).ToList().Where(x=>x.Contains(".png")).ToList();
        }

        public void Connect()
        {
            Thread.Sleep(1000);
            //Do something
            ConnectedEvent?.Invoke(this, null);
        }

        public void StartGrab()
        {
            Thread.Sleep(1000);
            //Do something
            GrabStartedEvent?.Invoke(this, null);
        }

        public void StopGrab()
        {
            //Do something
            GrabStoppedEvent?.Invoke(this, null);
        }

        public void SWTrigger()
        {
            var rd = new Random();
            var index = rd.Next(_files.Count);
            var selectedFile = _files[index];

            using (var img = Cv2.ImRead(selectedFile, ImreadModes.Unchanged))
            {
                FrameGrabbedEvent?.Invoke(this, img.Clone());
            }
        }
        public void Disconnect()
        {
            //Do something
            DisconnectedEvent?.Invoke(this, null);
        }
    }
}
