using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningRabbitMQ.Relatorios;
using MassTransit;

namespace LearningRabbitMQ.Bus
{
    public class RelatorioSolicitadoEventConsumer : IConsumer<RelatorioSolicitadoEvent>
    {
        private readonly ILogger<RelatorioSolicitadoEventConsumer> _logger;

        public RelatorioSolicitadoEventConsumer(ILogger<RelatorioSolicitadoEventConsumer> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<RelatorioSolicitadoEvent> context)
        {
            var message = context.Message;
           _logger.LogInformation($"Processando Relatório Id: {message.Id} Nome: {message.Name}");

           await Task.Delay(120000);
           var relatorio = Lista.Relatorios.FirstOrDefault(x => x.Id == message.Id);
           if(relatorio is not null)
           {
                relatorio.Status = "Completo";
                relatorio.ProcessedTime = DateTime.Now; 
           }
           _logger.LogInformation($"Relatório Completo Id: {message.Id} Nome: {message.Name}");
        }
    }
}