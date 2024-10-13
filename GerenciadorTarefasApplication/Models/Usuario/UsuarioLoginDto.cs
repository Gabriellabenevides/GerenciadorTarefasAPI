using System.ComponentModel.DataAnnotations;

namespace GerenciadorTarefas.Application.Models.Usuario
{
    public class UsuarioLoginDto
    {
        [Required(ErrorMessage = "O E-mail é obrigatório!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "A Senha é obrigatória!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
