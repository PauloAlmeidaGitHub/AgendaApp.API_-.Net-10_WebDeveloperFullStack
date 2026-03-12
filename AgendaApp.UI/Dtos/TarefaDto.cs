namespace AgendaApp.UI.Dtos
{
    public class TarefaDto
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Data { get; set; }
        public string? Hora { get; set; }
        public string? Descricao { get; set; }
        public string? Prioridade { get; set; }
    }
}