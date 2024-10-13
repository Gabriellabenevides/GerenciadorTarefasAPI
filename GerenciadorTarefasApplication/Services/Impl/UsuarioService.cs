using GerenciadorTarefas.Application.Models.Usuario;
using GerenciadorTarefas.Application.Services.Interfaces;
using GerenciadorTarefas.Core.Entities;

namespace GerenciadorTarefas.Application.Services.Impl
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository repository)
        {
            _usuarioRepository = repository;
        }

        public async Task<Usuario> Consultar(int Id)
        {
            var usuario = await _usuarioRepository.Consultar(Id);
            return usuario;
        }

        public async Task<Usuario> Create(UsuarioDto usuarioDto)
        {
            var usuario = new Usuario
            {
                Nome = usuarioDto.NomeUsuario,
                Email = usuarioDto.Email,
                CPF = usuarioDto.CPF
            };

            if (string.IsNullOrEmpty(usuarioDto.Password))
            {
                throw new ArgumentException("A senha não pode ser nula.");
            }

            using var hmac = new System.Security.Cryptography.HMACSHA512();
            usuario.PasswordSalt = hmac.Key;
            usuario.PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(usuarioDto.Password));

            await _usuarioRepository.Create(usuario);
            return usuario;
        }
            public async Task<Usuario> Delete(int Id)
        {
            var usuario = await _usuarioRepository.Delete(Id);
            return usuario;
        }

        public async Task<Usuario> Update(int id, UsuarioDto usuarioDto)
        {
            var usuario = await _usuarioRepository.Consultar(id);
            if (usuario == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            usuario.Nome = usuarioDto.NomeUsuario;
            usuario.Email = usuarioDto.Email;
            usuario.CPF = usuarioDto.CPF;

            await _usuarioRepository.Update(usuario);

            return usuario;
        }
    }
}
