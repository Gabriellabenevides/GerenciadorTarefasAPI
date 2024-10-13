using static GerenciadorTarefas.Core.Entities.Tarefa;

namespace GerenciadorTarefas.Application.Models.Tarefa
{
    public class UpdateTarefaDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public StatusTarefa Status { get; set; }
        public string Usuario { get; set; }
    }
}
