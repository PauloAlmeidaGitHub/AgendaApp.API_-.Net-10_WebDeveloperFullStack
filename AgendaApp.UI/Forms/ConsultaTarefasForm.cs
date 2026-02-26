using System.ComponentModel.DataAnnotations;

namespace AgendaApp.UI.Forms
{
    /// <summary>
    /// Modelo de dados para o formulário de consulta de tarefas
    /// </summary>
    public class ConsultaTarefasForm
    {
        [Required(ErrorMessage = "Por favor, informe a data de início da pesquisa.")]
        public string DataMin { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data de fim da pesquisa.")]
        public string DataMax { get; set; }
    }
}
