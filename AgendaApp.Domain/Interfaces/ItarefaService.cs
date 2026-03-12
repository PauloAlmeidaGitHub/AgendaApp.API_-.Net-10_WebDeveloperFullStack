using AgendaApp.Domain.Entities;
using AgendaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaApp.Domain.Interfaces
{
    public interface ITarefaService
    {
        void Adicionar(Tarefa tarefa);

        void Atualizar(Tarefa tarefa);

        void Excluir(Guid id);

        List<Tarefa> Consultar(DateOnly dataMin, DateOnly dataMax, int page, int pageSize);

        int Count(DateOnly dataMin, DateOnly dataMax);

        Tarefa? ObterPorId(Guid id);

        DashboardModel ObterDashboard(DateOnly dataMin, DateOnly dataMax);
    }
}
