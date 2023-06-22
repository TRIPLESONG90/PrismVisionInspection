using PrismVisionInspection.Services.Interfaces;

namespace PrismVisionInspection.Services
{
    public class MessageService : IMessageService
    {
        public string GetMessage()
        {
            return "Hello from the Message Service";
        }
    }
}
