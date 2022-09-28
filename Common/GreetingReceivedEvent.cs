using NServiceBus;

namespace Upmc.ServiceBus.Messages
{
    public class GreetingReceivedEvent : MessageBase, IEvent
    {
        public string Greeting { get; set; }
    }
}
