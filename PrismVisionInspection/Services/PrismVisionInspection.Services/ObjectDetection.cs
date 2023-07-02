using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Net.Http.Json;

namespace PrismVisionInspection.Services
{
    public class Response
    {
        public List<Rect> Results { get; set; }
    }
    public class Rect
    {
        public string Name { get; set; }
        public double Confidence { get; set; }
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }
    }
    public class ObjectDetection
    {
        HttpClient _client;
        public ObjectDetection(HttpClient client)
        {
            _client = client;
        }

        public List<Rect> Detect(Mat img)
        {
            byte[] data;
            Cv2.ImEncode(".jpg", img, out data);


            var requestContent = new MultipartFormDataContent();
            var imageContent = new ByteArrayContent(data);
            imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpg");
            requestContent.Add(imageContent, "file", "tmp.jpg");

            var response = _client.PostAsync("inspection", requestContent).Result;
            var results = response.Content.ReadFromJsonAsync<Response>().Result;

            return results.Results;
        }

        public void DrawRects(ref Mat img, List<Rect> rects)
        {
            foreach (var rect in rects)
            {
                int x = rect.X1;
                int y = rect.Y1;
                int w = rect.X2 - rect.X1;
                int h = rect.Y2 - rect.Y1;
                Cv2.Rectangle(img, new OpenCvSharp.Rect(x, y, w, h), new Scalar(255, 0, 0), 2);
                Cv2.PutText(img, rect.Name, new Point(x, y - 10), HersheyFonts.HersheyComplex, 2, new Scalar(0, 255, 0));
            }
        }
    }
}
