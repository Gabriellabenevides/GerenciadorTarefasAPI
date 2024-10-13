using GerenciadorTarefas.Core.Entities;
using GerenciadorTarefas.DataAcess.Persistence;
using GerenciadorTarefas.DataAcess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorTarefas.DataAcess.Repositories.Impl
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly DataContext _context;
        public TarefaRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Tarefa> ConsultarPorId(int id)
        {
            var tarefa = await _context.Tarefas
            .Include(t => t.Usuario)
            .FirstOrDefaultAsync(t => t.Id == id); 

            if (tarefa == null)
            {
                throw new Exception("Tarefa não encontrada");
            }
            return tarefa;
        }

        public async Task<Tarefa> Create(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();
            return tarefa;
        }

        public async Task<Tarefa> Delete(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa == null)
            {
                throw new Exception("Tarefa não encontrada");
            }

            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();
            return tarefa;
        }

        public async Task<Tarefa> Update(Tarefa tarefa)
        {
            _context.Tarefas.Update(tarefa);
            await _context.SaveChangesAsync();
            return tarefa;
        }

        public async Task<List<Tarefa>> ConsultarTarefasPorUsuario(int usuarioId)
        {
            var tarefas = await _context.Tarefas
            .Include(t => t.Usuario)
            .Where(t => t.UsuarioID == usuarioId)
            .ToListAsync();

            if (tarefas == null || !tarefas.Any())
            {
                throw new Exception("Nenhuma tarefa encontrada para este usuário.");
            }

            return tarefas;
        }
    }
}
