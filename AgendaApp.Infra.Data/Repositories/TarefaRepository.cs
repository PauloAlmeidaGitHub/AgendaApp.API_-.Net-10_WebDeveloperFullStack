using AgendaApp.Domain.Entities;
using AgendaApp.Domain.Enums;
using AgendaApp.Domain.Interfaces.Repositories;
using AgendaApp.Domain.Models;
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

        public List<Tarefa> Find(DateOnly dataMin, DateOnly dataMax, int page, int pageSize)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Tarefa>()
                        .Where(t => t.Data >= dataMin && t.Data <= dataMax)
                        .OrderByDescending(t => t.Data)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
            }
        }

        public int Count(DateOnly dataMin, DateOnly dataMax)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Tarefa>()
                        .Count(t => t.Data >= dataMin && t.Data <= dataMax);
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

        public DashboardModel GenerateDashboard(DateOnly dataMin, DateOnly dataMax)
        {
            using (var dataContext = new DataContext())
            {
                var tarefas = dataContext.Set<Tarefa>()
                                .Where(t => t.Data >= dataMin
                                         && t.Data <= dataMax)
                                .ToList();

                var model = new DashboardModel
                {
                    TotalTarefas = tarefas.Count,
                    TotalPrioridadeAlta = tarefas.Count(t => t.Prioridade == Prioridade.ALTA),
                    TotalPrioridadeMedia = tarefas.Count(t => t.Prioridade == Prioridade.MEDIA),
                    TotalPrioridadeBaixa = tarefas.Count(t => t.Prioridade == Prioridade.BAIXA)
                };

                return model;
            }
        }
    }
}
