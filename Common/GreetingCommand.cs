using NServiceBus;

namespace Upmc.ServiceBus.Messages
{
    public class GreetingCommand : MessageBase, ICommand
    {
        public string Greeting { get; set; }
    }
}
