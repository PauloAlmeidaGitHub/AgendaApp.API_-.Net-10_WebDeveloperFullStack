using AgendaApp.Domain.Entities;
using AgendaApp.Domain.Interfaces;
using AgendaApp.Domain.Interfaces.Repositories;
using AgendaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaApp.Domain.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaService(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public void Adicionar(Tarefa tarefa)
        {
            _tarefaRepository.Add(tarefa);
        }

        public void Atualizar(Tarefa tarefa)
        {
            _tarefaRepository.Update(tarefa);
        }

        public List<Tarefa> Consultar(DateOnly dataMin, DateOnly dataMax, int page, int pageSize)
        {
            return _tarefaRepository.Find(dataMin, dataMax, page, pageSize);
        }

        public int Count(DateOnly dataMin, DateOnly dataMax)
        {
            return _tarefaRepository.Count(dataMin, dataMax);
        }

        public void Excluir(Guid id)
        {
            var tarefa = _tarefaRepository.FindById(id);
            _tarefaRepository.Delete(tarefa);
        }

        public DashboardModel ObterDashboard(DateOnly dataMin, DateOnly dataMax)
        {
            return _tarefaRepository.GenerateDashboard(dataMin, dataMax);
        }

        public Tarefa? ObterPorId(Guid id)
        {
            return _tarefaRepository.FindById(id);
        }
    }
}
