using GerenciadorTarefas.Application.Models.Usuario;
using GerenciadorTarefas.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorTarefasAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IAuthService authService, IUsuarioService usuarioService)
        {
            _authService = authService;
            _usuarioService = usuarioService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Create(UsuarioDto usuarioDto) 
        {
            if (usuarioDto == null)
            {
                return BadRequest("Dados inválidos!");
            }

            var emailExiste = await _authService.UserExist(usuarioDto.Email);
            if (emailExiste)
            {
                return BadRequest("Este e-mail já possui um cadastro");
            }

            var usuario = await _usuarioService.Create(usuarioDto);
            if (usuario == null)
            {
                return BadRequest("Ocorreu um erro ao cadastrar!");
            }

            var token = _authService.GenerateToken(usuario.Id, usuario.Email);

            return Ok(new UserToken
            {
                Token = token
            });
        }
        [HttpPost("login")]
        public async Task<ActionResult<UserToken>> Selecionar(UsuarioLoginDto loginDto)
        {
            var existe = await _authService.UserExist(loginDto.Email);
            {
                if (!existe)
                {
                    return Unauthorized("Usuário não existe");
                }
            }
            var result = await _authService.AutheticateAsync(loginDto.Email, loginDto.Password);
            {
                if (!result)
                {
                    return Unauthorized("Usuário ou senha inválido!");
                }
                var usuario = await _authService.GetUserByEmail(loginDto.Email);
                var token = _authService.GenerateToken(usuario.Id, usuario.Email);
                return new UserToken
                {
                    Token = token
                };
            }               
        }
    }
}
