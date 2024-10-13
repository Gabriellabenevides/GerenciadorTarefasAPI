using GerenciadorTarefas.Application.Models.Categoria;
using GerenciadorTarefas.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorTarefasAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {

            _categoriaService = categoriaService;
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultarPorId(int id)
        {
            try
            {
                var categoria = await _categoriaService.ConsultarPorId(id);
                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoriaDto categoriaDto)
        {
            await _categoriaService.Create(categoriaDto);
            return NoContent();

        }
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateCategoriaDto categoriaDto)
        {
            var categoria = await _categoriaService.Update(categoriaDto);
            if (categoria == false) return NotFound();
            return NoContent();
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var categoria = await _categoriaService.Delete(id);
            if (categoria == false) return NotFound();
            return NoContent();
        }
    }
}
