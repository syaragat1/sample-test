using NServiceBus;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Common
{
    public static class EndpointConfigurator
    {
        public static EndpointConfiguration ConfigureEndpoint(string endpointName)
        {
            Console.WriteLine($"Starting {endpointName} ...");

            var _endpointConfiguration = new EndpointConfiguration(endpointName);
            _endpointConfiguration.EnableInstallers();

            var persistenceSettings = _endpointConfiguration.UsePersistence<InMemoryPersistence>();
            _endpointConfiguration.SendFailedMessagesTo("error");
            _endpointConfiguration.AuditProcessedMessagesTo("audit");

            _endpointConfiguration.UseSerialization<NewtonsoftSerializer>();

            var transport = _endpointConfiguration.UseTransport<RabbitMQTransport>();
            transport.UseConventionalRoutingTopology();
            transport.ConnectionString(ApplicationSettings.RmqConnectionString);

            return _endpointConfiguration;
        }

        public static EndpointConfiguration ConfigureSqlPersistence(this EndpointConfiguration endpointConfiguration, string endpointName)
        {
            var persistenceSettings = endpointConfiguration.UsePersistence<SqlPersistence>();
            persistenceSettings.DisableInstaller();
            persistenceSettings.SqlDialect<SqlDialect.MsSqlServer>();
            persistenceSettings.TablePrefix($"{endpointName}.");
            persistenceSettings.ConnectionBuilder(() => new SqlConnection(ApplicationSettings.SqlConnectionString));

            return endpointConfiguration;
        }

        public static EndpointConfiguration ConfigureOutbox(this EndpointConfiguration endpointConfiguration, bool enableOutbox)
        {
            if (enableOutbox)
            {
                endpointConfiguration.EnableOutbox();
            }

            return endpointConfiguration;
        }

        public static async Task<IEndpointInstance> StartEndpoint(this EndpointConfiguration endpointConfiguration)
        {
            return await Endpoint.Start(endpointConfiguration);
        }

        public static EndpointConfiguration ConfigureCommandRoute(this EndpointConfiguration endpointConfiguration, string destinationEndpointName, Type commandType)
        {
            var transport = endpointConfiguration.UseTransport<RabbitMQTransport>();
            var routing = transport.Routing();
            routing.RouteToEndpoint(commandType, destinationEndpointName);
            return endpointConfiguration;
        }
    }
}
