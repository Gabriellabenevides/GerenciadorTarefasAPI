using GerenciadorTarefas.Application.Models.Tarefa;
using GerenciadorTarefas.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorTarefasAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefaController : Controller
    {
        private readonly ITarefaService _tarefaService;

        public TarefaController(ITarefaService tarefaService)
        {

            _tarefaService = tarefaService;
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultarPorId(int id)
        {
            try
            {
                var tarefa = await _tarefaService.ConsultarPorId(id);
                return Ok(tarefa);
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }
        [Authorize]
        [HttpGet("Usuario/{usuarioId}")]
        public async Task<IActionResult> ConsultarTarefasPorUsuario(int usuarioId)
        {
            try
            {
                var tarefas = await _tarefaService.ConsultarTarefasPorUsuario(usuarioId);
                return Ok(tarefas);
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTarefaDto tarefaDto)
        {
            try
            {
                await _tarefaService.Create(tarefaDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Erro inesperado: " + ex.Message });
            }

        }
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateTarefaDto tarefaDto)
        {
            var tarefaAtualizada = await _tarefaService.Update(id, tarefaDto);
            if (tarefaAtualizada == false) return NotFound();
            return NoContent();
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var tarefa = await _tarefaService.Delete(id);
            if (tarefa == false) return NotFound();
            return NoContent();
        }
    }
}
