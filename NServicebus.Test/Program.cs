using Common;
using NServiceBus.Logging;
using System;
using System.Threading.Tasks;

namespace NServicebus.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args)
        {
            var defaultFactory = LogManager.Use<DefaultFactory>();
            defaultFactory.Level(LogLevel.Debug);

            var endpointName = Console.Title = "Upmc.Endpoint1";
            var endpointInstance = await EndpointConfigurator
                .ConfigureEndpoint(endpointName)
                .ConfigureSqlPersistence(endpointName)
                .ConfigureOutbox(true)
                .StartEndpoint();

            Console.WriteLine("Press ENTER to stop service ...");
            Console.ReadLine();

            await endpointInstance.Stop();

        }
    }
}
