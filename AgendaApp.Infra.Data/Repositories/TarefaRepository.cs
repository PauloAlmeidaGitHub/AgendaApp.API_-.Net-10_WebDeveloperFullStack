using AgendaApp.Domain.Entities;
using AgendaApp.Domain.Interfaces.Repositories;
using AgendaApp.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaApp.Infra.Data.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        public void Add(Tarefa tarefa)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Add(tarefa);
                dataContext.SaveChanges();
            }
        }

        public void Delete(Tarefa tarefa)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Remove(tarefa);
                dataContext.SaveChanges();
            }
        }

        public List<Tarefa> Find(DateOnly dataMin, DateOnly dataMax)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Tarefa>()
                        .Where(t => t.Data >= dataMin && t.Data <= dataMax)
                        .OrderByDescending(t => t.Data)
                        .ToList();
            }
        }

        public Tarefa? FindById(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Tarefa>()
                    .FirstOrDefault(t => t.Id == id);
            }
        }

        public void Update(Tarefa tarefa)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Update(tarefa);
                dataContext.SaveChanges();
            }
        }
    }
}
