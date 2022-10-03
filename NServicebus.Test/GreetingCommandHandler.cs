using Common;
using NServiceBus;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Upmc.ServiceBus.Messages;

namespace NServicebus.Test
{
    public class GreetingCommandHandler : IHandleMessages<GreetingCommand>
    {
        public async Task Handle(GreetingCommand message, IMessageHandlerContext context)
        {
            await Task.Delay(500);

            var sb = new StringBuilder();
            sb.AppendLine(message.Greeting);
            sb.AppendLine(File.ReadAllText("logs/sample.txt"));

            //Console.WriteLine($"Received Greeting: {message.Greeting}");
            var randomNumber = 2;// RandomNumberGenerator.Next;
            for (int i = 1; i <= randomNumber; i++)
            {
                await context.Publish(new GreetingReceivedEvent()
                {
                    Greeting = sb.ToString()
                });

                //await Task.Delay(100);

                //await context.Publish(new Greeting2ReceivedEvent()
                //{
                //    Greeting = sb.ToString()
                //});

                //await Task.Delay(100);

                await context.Publish(new Greeting3ReceivedEvent()
                {
                    Greeting = sb.ToString()
                });

                //await Task.Delay(100);

                //await context.Publish(new Greeting4ReceivedEvent()
                //{
                //    Greeting = sb.ToString()
                //});

                //await Task.Delay(100);
            }
        }
    }
}
