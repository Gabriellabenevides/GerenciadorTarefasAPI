using GerenciadorTarefas.Application.Models.Categoria;
using GerenciadorTarefas.Core.Entities;

namespace GerenciadorTarefas.Application.Services.Interfaces
{
    public interface ICategoriaService
    {
        Task<bool> Create(CreateCategoriaDto categoriaDto);
        Task<bool> Update(UpdateCategoriaDto categoriaDto);
        Task<bool> Delete(int id);
        Task<ReadCategoriaDto> ConsultarPorId(int id);
    }
}
