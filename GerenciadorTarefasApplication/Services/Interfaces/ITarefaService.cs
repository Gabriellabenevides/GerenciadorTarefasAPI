using GerenciadorTarefas.Application.Models.Tarefa;

namespace GerenciadorTarefas.Application.Services.Interfaces
{
    public interface ITarefaService
    {
        Task<bool> Create(CreateTarefaDto tarefaDto);
        Task<bool> Update(int id, UpdateTarefaDto tarefaDto);
        Task<bool> Delete(int id);
        Task<ReadTarefaDto> ConsultarPorId(int id);
        Task<List<ReadTarefaDto>> ConsultarTarefasPorUsuario(int usuarioId);
    }
}
