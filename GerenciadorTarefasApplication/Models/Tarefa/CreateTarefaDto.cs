using System.ComponentModel.DataAnnotations;
using static GerenciadorTarefas.Core.Entities.Tarefa;

namespace GerenciadorTarefas.Application.Models.Tarefa
{
    public class CreateTarefaDto
    {
        [Required(ErrorMessage = "O Título é obrigatório")]
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public StatusTarefa Status { get; set; }
        public DateTime DataCriacao { get; set; }
        public int UsuarioID { get; set; }
    }
}
