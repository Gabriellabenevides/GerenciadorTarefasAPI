namespace GerenciadorTarefas.Core.Entities
{
    public class Usuario 
    {
        public int Id { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public virtual ICollection<Tarefa> Tarefas { get; set; }
        public Usuario() { }

        public void Update(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }

        public Usuario(string nome, string cpf, string email, string password)
        {
            Nome = nome;
            CPF = cpf;
            Email = email;


        }
    }
}