using NServiceBus;

namespace Upmc.ServiceBus.Messages
{
    public class GreetingReceivedEvent : IEvent
    {
        public string Greeting { get; set; }
    }
}
