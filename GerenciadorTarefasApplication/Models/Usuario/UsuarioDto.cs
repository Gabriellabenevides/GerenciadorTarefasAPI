using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciadorTarefas.Application.Models.Usuario
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O Nome é obrigatório!")]
        [MaxLength(100, ErrorMessage = "O nome não pode ter mais de 100 caracteres!")]
        public string NomeUsuario { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "A Senha é obrigatória!")]
        [MaxLength(100, ErrorMessage = "A Senha não pode ter mais de 100 caracteres!")]
        public string Password { get; set; }
        [Required(ErrorMessage = "O E-mail é obrigatório!")]
        [MinLength(10, ErrorMessage = "O E-mail não pode ter menos de 8 caracteres!")]
        public string Email { get; set; }
        public string CPF { get; set; }
    }
}
