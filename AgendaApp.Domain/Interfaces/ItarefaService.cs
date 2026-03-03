using AgendaApp.Domain.Entities;
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

        List<Tarefa> Consultar(DateOnly dataMin, DateOnly dataMax);

        Tarefa? ObterPorId(Guid id);
    }
}
