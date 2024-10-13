using GerenciadorTarefas.Core.Entities;

namespace GerenciadorTarefas.DataAcess.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<Categoria> Create(Categoria categoria);
        Task<Categoria> Update(Categoria categoria);
        Task<Categoria> Delete(int id);
        Task<Categoria> ConsultarPorId(int id);
    }
}
