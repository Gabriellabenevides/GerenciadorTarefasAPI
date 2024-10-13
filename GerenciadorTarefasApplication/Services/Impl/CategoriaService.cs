using GerenciadorTarefas.Application.Models.Categoria;
using GerenciadorTarefas.Application.Services.Interfaces;
using GerenciadorTarefas.Core.Entities;
using GerenciadorTarefas.DataAcess.Repositories.Interfaces;

namespace GerenciadorTarefas.Application.Services.Impl
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository repository, ITarefaRepository tarefaRepository)
        {
            _categoriaRepository = repository;
            _tarefaRepository = tarefaRepository;
        }
        public async Task<ReadCategoriaDto> ConsultarPorId(int id)
        {
            var categoria = await _categoriaRepository.ConsultarPorId(id);
            if (categoria == null)
            {
                throw new Exception("Categoria não encontrada.");
            }

            return new ReadCategoriaDto
            {
                Id = categoria.Id,
                Nome = categoria.Nome,
                TarefaId = categoria.TarefaId
            };
        }

        public async Task<bool> Create(CreateCategoriaDto categoriaDto)
        {
            var categoria = new Categoria(categoriaDto.Nome, categoriaDto.TarefaId);
            await _categoriaRepository.Create(categoria);
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var categoria = await _categoriaRepository.ConsultarPorId(id);
            if (categoria == null)
            {
                return false;
            }
            await _categoriaRepository.Delete(id);
            return true;
        }

        public async Task<bool> Update(UpdateCategoriaDto categoriaDto)
        {
            var categoria = await _categoriaRepository.ConsultarPorId(categoriaDto.Id);
            if (categoria == null)
            {
                throw new Exception("Categoria não encontrada.");
            }

            categoria.Nome = categoriaDto.Nome;
            categoria.TarefaId = categoriaDto.TarefaId;
            await _categoriaRepository.Update(categoria);

            return true;
        }
    }
}
