using System;
using System.Threading.Tasks;
using Common;
using NServiceBus;
using NServiceBus.Logging;
using Upmc.ServiceBus.Messages;

namespace NServicebus.Test2
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();

            Console.WriteLine("Press ENTER to stop service ...");
            Console.ReadLine();
        }

        static async Task MainAsync(string[] args)
        {
            var defaultFactory = LogManager.Use<DefaultFactory>();
            defaultFactory.Level(LogLevel.Debug);

            var endpointName = Console.Title = "Upmc.Endpoint2";
            var endpointInstance = await EndpointConfigurator.ConfigureEndpoint(endpointName)
                .ConfigureCommandRoute("Upmc.Endpoint1", typeof(GreetingCommand))
                //.ConfigureOutbox(true)
                .StartEndpoint();

            for (int i = 0; i < 10000; i++)
            {
                Console.WriteLine(i);
                await endpointInstance.Send(new GreetingCommand { Greeting = "Hello!" });
            }
        }
    }
}
