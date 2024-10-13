using GerenciadorTarefas.Core.Entities;

namespace GerenciadorTarefas.Application.Services.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> Create(Usuario usuario);
        Task<Usuario> Update(Usuario usuario);
        Task<Usuario> Delete(int Id);
        Task<Usuario> Consultar(int Id);
    }
}
