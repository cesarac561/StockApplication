using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Stock.Domain.Repositories;
using Stock.Infrastructure.Repositories;
using MongoDB.Driver;
using Confluent.Kafka;
using Stock.Domain.Service.Events;
using Stock.Infrastructure.Services.Events;
using System.Net;


namespace Stock.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfraestructure(
            this IServiceCollection services, string connectionString
            )
        {

            services.AddDataBaseFactories(connectionString);
            services.AddRepositories();
            services.AddProducer();
            services.AddEventServices();
        }

        private static void AddDataBaseFactories(this IServiceCollection services, string connectionString)
        {            
            services.AddSingleton(mongoDatabase =>
            {
                var mongoClient = new MongoClient(connectionString);
                return mongoClient.GetDatabase("db-productos-stocks");
            });

        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductoRepository, ProductoRepository>();

            
        }

        private static IServiceCollection AddProducer(this IServiceCollection services)
        {
            var config = new ProducerConfig
            {
                Acks = Acks.Leader,
                BootstrapServers = "127.0.0.1:9092",
                ClientId = Dns.GetHostName(),
            };

            services.AddSingleton<IPublisherFactory>(sp => new PublisherFactory(config));
            return services;
        }

        private static void AddEventServices(this IServiceCollection services)
        {
            services.AddSingleton<IEventSender, EventSender>();
        }
    }
}
