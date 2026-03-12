using AgendaApp.Domain.Entities;
using AgendaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaApp.Domain.Interfaces.Repositories
{
    public interface ITarefaRepository
    {
        void Add(Tarefa tarefa);
        void Update(Tarefa tarefa);
        void Delete(Tarefa tarefa);
        List<Tarefa> Find(DateOnly dataMin, DateOnly dataMax, int page, int pageSize);
        int Count(DateOnly dataMin, DateOnly dataMax);
        Tarefa? FindById(Guid id);
        DashboardModel GenerateDashboard(DateOnly dataMin, DateOnly dataMax);
    }
}