namespace AgendaApp.API.Dtos
{
    public record TarefaResponse(
            Guid id,
            string nome,
            string data,
            string hora,
            string descricao,
            string prioridade
        );
}
