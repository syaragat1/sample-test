using Common;
using NServiceBus;
using System.Threading.Tasks;
using Upmc.ServiceBus.Messages;

namespace Upmc.Endpoint2
{
    public class GreetingEventHandler2 : IHandleMessages<Greeting2ReceivedEvent>
    {
        public async Task Handle(Greeting2ReceivedEvent message, IMessageHandlerContext context)
        {
            //Console.WriteLine($"Received event: {message.GetType().FullName} ({context.MessageId})");           

            await Task.CompletedTask;
        }
    }
}
