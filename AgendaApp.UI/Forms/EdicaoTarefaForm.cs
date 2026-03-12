using System.ComponentModel.DataAnnotations;

namespace AgendaApp.UI.Forms
{
    public class EdicaoTarefaForm
    {
        [MinLength(6, ErrorMessage = "Por favor, informe o nome com pelo menos {1} caracteres.")]
        [MaxLength(100, ErrorMessage = "Por favor, informe o nome com no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, inform o nome da tarefa.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data da tarefa.")]
        public string? Data { get; set; }

        [Required(ErrorMessage = "Por favor, informe a hora da tarefa.")]
        public string? Hora { get; set; }

        [Required(ErrorMessage = "Por favor, selecione a prioridade da tarefa.")]
        public string? Prioridade { get; set; }

        [MinLength(6, ErrorMessage = "Por favor, informe a descrição com pelo menos {1} caracteres.")]
        [MaxLength(250, ErrorMessage = "Por favor, informe a descrição com no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe a descrição da tarefa.")]
        public string? Descricao { get; set; }
    }
}
