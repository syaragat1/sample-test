using NServiceBus;

namespace Upmc.ServiceBus.Messages
{
    public class GreetingCommand : ICommand
    {
        public string Greeting { get; set; }
    }
}
