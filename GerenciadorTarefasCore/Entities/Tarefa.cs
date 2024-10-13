using System.Text.Json.Serialization;

namespace GerenciadorTarefas.Core.Entities
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public StatusTarefa Status { get; set; }
        public DateTime DataCriacao { get; set; }
        public int UsuarioID { get; set; }
        public virtual Usuario Usuario { get; set; }
        public Tarefa()
        {
        }
        public enum StatusTarefa
        {
            [JsonConverter(typeof(JsonStringEnumConverter))]
            Pendente,
            EmAndamento,
            Concluida
        }
        public Tarefa(string titulo, string descricao, Enum status, int usuarioId)
        {            
            DataCriacao = DateTime.Now;
            Titulo = titulo;
            Descricao = descricao;
            UsuarioID = usuarioId;
        }

        public void AtualizarStatus(StatusTarefa novoStatus)
        {
            Status = novoStatus;
        }
        public void Update(string titulo, string descricao)
        {
            Titulo = titulo;
            Descricao = descricao;
        }
    }
}