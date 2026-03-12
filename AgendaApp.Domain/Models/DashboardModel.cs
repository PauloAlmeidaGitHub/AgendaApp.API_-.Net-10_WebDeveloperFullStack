using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaApp.Domain.Models
{
    public class DashboardModel
    {
        public int TotalTarefas { get; set; }
        public int TotalPrioridadeAlta { get; set; }
        public int TotalPrioridadeMedia { get; set; }
        public int TotalPrioridadeBaixa { get; set; }
    }
}
