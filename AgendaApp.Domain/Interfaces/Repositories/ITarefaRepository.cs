using AgendaApp.Domain.Entities;
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
        List<Tarefa> Find(DateOnly dataMin, DateOnly dataMax);
        Tarefa? FindById(Guid id);
    }
}