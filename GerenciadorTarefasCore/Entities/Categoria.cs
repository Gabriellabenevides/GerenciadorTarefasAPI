using Microsoft.EntityFrameworkCore.Update.Internal;

namespace GerenciadorTarefas.Core.Entities
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int TarefaId { get; set; }
        public virtual Tarefa Tarefa { get; set; }
        public Categoria()
        {
        }
        public Categoria(string nome, int tarefaId)
        {
            Nome = nome;
            TarefaId = tarefaId;
        }
    }
}
