using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningRabbitMQ.Bus;
using MassTransit;

namespace LearningRabbitMQ.Extensions
{
    public static class AppExtensions
    {
        public static void AddRabbitMQService(this IServiceCollection services)
        {
            services.AddMassTransit(busConfigurator =>
            {
                busConfigurator.AddConsumer<RelatorioSolicitadoEventConsumer>();
                busConfigurator.UsingRabbitMq((ctx, cfg)=>
                {
                    cfg.Host(new Uri("amqp://localhost:5672"), host=>
                    {
                        host.Username("guest");
                        host.Password("guest");
                    });
                    cfg.ConfigureEndpoints(ctx);
                });
            });
        }
    }
}