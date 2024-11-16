using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningRabbitMQ.Relatorios
{
    public class Lista
    {
        public static List<SolicitacaoRelatorio> Relatorios = [];
    }

    public class SolicitacaoRelatorio
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Status { get; set; }
        public DateTime? ProcessedTime { get; set; }
    }
}