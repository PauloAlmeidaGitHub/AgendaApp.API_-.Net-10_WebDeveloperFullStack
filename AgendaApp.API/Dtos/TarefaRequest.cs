namespace AgendaApp.API.Dtos
{
    public record TarefaRequest(
            string nome,
            string data,
            string hora,
            string descricao,
            string prioridade
        );
}
