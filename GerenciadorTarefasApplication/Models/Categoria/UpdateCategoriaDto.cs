namespace GerenciadorTarefas.Application.Models.Categoria
{
    public class UpdateCategoriaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int TarefaId { get; set; }
    }
}
