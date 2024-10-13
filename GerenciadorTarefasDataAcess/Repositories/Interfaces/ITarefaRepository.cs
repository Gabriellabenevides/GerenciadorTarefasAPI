using GerenciadorTarefas.Core.Entities;

namespace GerenciadorTarefas.DataAcess.Repositories.Interfaces
{
    public interface ITarefaRepository
    {
        Task<Tarefa> Create(Tarefa tarefa);
        Task<Tarefa> Update(Tarefa tarefa);
        Task<Tarefa> Delete(int id);
        Task<Tarefa> ConsultarPorId(int id);
        Task<List<Tarefa>> ConsultarTarefasPorUsuario(int usuarioId);

    }
}
