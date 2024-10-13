using GerenciadorTarefas.Application.Models.Tarefa;
using GerenciadorTarefas.Application.Services.Interfaces;
using GerenciadorTarefas.Core.Entities;
using GerenciadorTarefas.DataAcess.Repositories.Interfaces;

namespace GerenciadorTarefas.Application.Services.Impl
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public TarefaService(ITarefaRepository repository, IUsuarioRepository usuarioRepository)
        {
            _tarefaRepository = repository;
            _usuarioRepository = usuarioRepository;
        }
        public async Task<ReadTarefaDto> ConsultarPorId(int id)
        {
            var tarefa = await _tarefaRepository.ConsultarPorId(id);
            if (tarefa == null)
            {
                throw new Exception("Tarefa não encontrada.");
            }

            return new ReadTarefaDto
            {
                Id = tarefa.Id,
                Titulo = tarefa.Titulo,
                Descricao = tarefa.Descricao,
                Status = tarefa.Status,
                DataCriacao = tarefa.DataCriacao,
                UsuarioID = tarefa.UsuarioID,
                Usuario = tarefa.Usuario.Nome
            };
        }

        public async Task<List<ReadTarefaDto>> ConsultarTarefasPorUsuario(int usuarioId)
        {
            var tarefas = await _tarefaRepository.ConsultarTarefasPorUsuario(usuarioId);
            if (tarefas == null || !tarefas.Any())
            {
                throw new Exception("Nenhuma tarefa encontrada para o usuário.");
            }

            return tarefas.Select(tarefa => new ReadTarefaDto
            {
                Id = tarefa.Id,
                Titulo = tarefa.Titulo,
                Descricao = tarefa.Descricao,
                Status = tarefa.Status,
                DataCriacao = tarefa.DataCriacao,
                UsuarioID = tarefa.UsuarioID,
                Usuario = tarefa.Usuario.Nome,
            }).ToList();
        }

        public async Task<bool> Create(CreateTarefaDto tarefaDto)
        {
            var usuario = await _usuarioRepository.Consultar(tarefaDto.UsuarioID);
            if (usuario == null)
            {
                throw new Exception("Usuário não encontrado.");
            }

            var tarefa = new Tarefa(tarefaDto.Titulo, tarefaDto.Descricao, tarefaDto.Status, tarefaDto.UsuarioID);
            await _tarefaRepository.Create(tarefa);

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var tarefa = await _tarefaRepository.ConsultarPorId(id);
            if (tarefa == null)
            {
                return false;
            }
            await _tarefaRepository.Delete(id);
            return true;
        }

        public async Task<bool> Update(int id, UpdateTarefaDto tarefaDto)
        {
            var tarefaExistente = await _tarefaRepository.ConsultarPorId(tarefaDto.Id);
            if (tarefaExistente == null)
            {
                throw new Exception("Tarefa não encontrada.");
            }

            tarefaExistente.Update(tarefaDto.Titulo, tarefaDto.Descricao);
            await _tarefaRepository.Update(tarefaExistente);
            return true;
        }
    }
}
