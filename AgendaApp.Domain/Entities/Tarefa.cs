using AgendaApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaApp.Domain.Entities
{
    public class Tarefa
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; } = string.Empty;
        public DateOnly Data { get; set; }
        public TimeSpan Hora { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public Prioridade Prioridade { get; set; }
    }
}