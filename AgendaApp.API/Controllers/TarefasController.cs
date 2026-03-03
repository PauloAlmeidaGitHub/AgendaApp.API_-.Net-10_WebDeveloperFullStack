using AgendaApp.API.Dtos;
using AgendaApp.Domain.Entities;
using AgendaApp.Domain.Enums;
using AgendaApp.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

            return Ok(new TarefaResponse(
                    tarefa.Id,
                    tarefa.Nome,
                    tarefa.Data.ToString(),
                    tarefa.Hora.ToString(),
                    tarefa.Descricao,
                    tarefa.Prioridade.ToString()
                ));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(TarefaResponse), 200)]
        public IActionResult Put(Guid id, [FromBody] TarefaRequest request)
        {
            return Ok();
        }

        [ProducesResponseType(typeof(TarefaResponse), 200)]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            return Ok();
        }

        [ProducesResponseType(typeof(List<TarefaResponse>), 200)]
        [HttpGet("{dataMin}/{dataMax}")]
        public IActionResult Get(string dataMin, string dataMax)
        {
            return Ok();
        }

        [ProducesResponseType(typeof(TarefaResponse), 200)]
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            return Ok();
        }
    }
}
