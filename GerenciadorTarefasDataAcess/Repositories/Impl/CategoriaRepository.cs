using GerenciadorTarefas.Core.Entities;
using GerenciadorTarefas.DataAcess.Persistence;
using GerenciadorTarefas.DataAcess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorTarefas.DataAcess.Repositories.Impl
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly DataContext _context;
        public CategoriaRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Categoria> ConsultarPorId(int id)
        {
            var categoria = await _context.Categorias
                        .Include(t => t.Tarefa)
                        .FirstOrDefaultAsync(t => t.Id == id);

            if (categoria == null)
            {
                throw new Exception("Categoria não encontrada");
            }
            return categoria;
        }

        public async Task<Categoria> Create(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> Delete(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                throw new Exception("Tarefa não encontrada");
            }

            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> Update(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }
    }
}
