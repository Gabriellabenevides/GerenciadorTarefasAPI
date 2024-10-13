using GerenciadorTarefas.Core.Entities;

namespace GerenciadorTarefas.Application.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> AutheticateAsync(string email, string password);
        Task<bool> UserExist(string email);
        public string GenerateToken(int id, string email);
        public Task<Usuario> GetUserByEmail(string email);
    }
}
