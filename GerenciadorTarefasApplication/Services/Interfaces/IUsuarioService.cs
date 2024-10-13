using GerenciadorTarefas.Application.Models.Usuario;
using GerenciadorTarefas.Core.Entities;

namespace GerenciadorTarefas.Application.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario> Create(UsuarioDto usuario);
        Task<Usuario> Update(int id, UsuarioDto usuario);
        Task<Usuario> Delete(int Id);
        Task<Usuario> Consultar(int Id);

    }
}
