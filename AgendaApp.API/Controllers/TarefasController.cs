using AgendaApp.API.Dtos;
using AgendaApp.Domain.Entities;
using AgendaApp.Domain.Enums;
using AgendaApp.Domain.Interfaces;
using AgendaApp.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AgendaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefaService _tarefaService;

        public TarefasController(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(TarefaResponse), 201)]
        public IActionResult Post([FromBody] TarefaRequest request)
        {
            var tarefa = new Tarefa
            {
                Nome = request.nome,
                Data = DateOnly.Parse(request.data),
                Hora = TimeSpan.Parse(request.hora),
                Descricao = request.descricao,
                Prioridade = Enum.Parse<Prioridade>(request.prioridade)
            };

            _tarefaService.Adicionar(tarefa);

            return Ok(ParseToResponse(tarefa));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(TarefaResponse), 200)]
        public IActionResult Put(Guid id, [FromBody] TarefaRequest request)
        {
            var tarefa = _tarefaService.ObterPorId(id);

            if (tarefa == null)
                return NotFound(new { message = "Tarefa não encontrada." });

            tarefa.Nome = request.nome;
            tarefa.Data = DateOnly.Parse(request.data);
            tarefa.Hora = TimeSpan.Parse(request.hora);
            tarefa.Descricao = request.descricao;
            tarefa.Prioridade = Enum.Parse<Prioridade>(request.prioridade);

            _tarefaService.Atualizar(tarefa);

            return Ok(ParseToResponse(tarefa));
        }

        [ProducesResponseType(typeof(TarefaResponse), 200)]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var tarefa = _tarefaService.ObterPorId(id);

            if (tarefa == null)
                return NotFound(new { message = "Tarefa não encontrada." });

            _tarefaService.Excluir(id);

            return Ok(ParseToResponse(tarefa));
        }

        [ProducesResponseType(typeof(List<TarefaResponse>), 200)]
        [HttpGet("{dataMin}/{dataMax}")]
        public IActionResult Get(string dataMin, string dataMax, int page = 1, int pageSize = 10)
        {
            var dtMin = DateOnly.Parse(dataMin);
            var dtMax = DateOnly.Parse(dataMax);

            var tarefas = _tarefaService.Consultar(dtMin, dtMax, page, pageSize);

            if (!tarefas.Any())
                return NoContent();

            var response = new PaginacaoResponse<TarefaResponse>
            {
                Page = page,
                PageSize = pageSize,
                TotalRecords = _tarefaService.Count(dtMin, dtMax),
                Data = tarefas.Select(t => ParseToResponse(t)).ToList()
            };

            return Ok(response);
        }

        [ProducesResponseType(typeof(TarefaResponse), 200)]
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var tarefa = _tarefaService.ObterPorId(id);

            if (tarefa == null)
                return NotFound();

            return Ok(ParseToResponse(tarefa));
        }

        [ProducesResponseType(typeof(DashboardModel), 200)]
        [HttpGet("dashboard/{dataMin}/{dataMax}")]
        public IActionResult GetDashboard(string dataMin, string dataMax)
        {
            var dtMin = DateOnly.Parse(dataMin);
            var dtMax = DateOnly.Parse(dataMax);

            return Ok(_tarefaService.ObterDashboard(dtMin, dtMax));
        }

        private TarefaResponse ParseToResponse(Tarefa tarefa)
        {
            return new TarefaResponse(
                    tarefa.Id,
                    tarefa.Nome,
                    tarefa.Data.ToString(),
                    tarefa.Hora.ToString(),
                    tarefa.Descricao,
                    tarefa.Prioridade.ToString()
                );
        }
    }
}
