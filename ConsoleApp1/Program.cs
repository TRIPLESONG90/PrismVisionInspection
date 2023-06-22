
using OpenCvSharp;
using PrismVisionInspection.Services;

var cam = new VirtualCamera(@"C:\Users\exper\Pictures\Screenshots");
cam.FrameGrabbedEvent += (s, e) =>
{
    Cv2.ImShow("asdf", e);
    Cv2.WaitKey();
};

//Start
cam.Connect();
cam.StartGrab();


//Triiger
cam.SWTrigger();

//Stop
cam.StopGrab();
cam.Disconnect();

Console.ReadLine();