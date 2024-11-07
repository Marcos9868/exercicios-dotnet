using ApiCatalogo.Data;
using ApiCatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly DataContext _context;
        public CategoriasController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categorias = await _context.Categorias.Include(p => p.Produtos).ToListAsync();
            if (categorias == null) return NotFound();
            return Ok(categorias);
        }
        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public async Task<IActionResult> Get(int id)
        {
            var categoria = await _context.Categorias.FirstOrDefaultAsync(p => p.Id == id);
            if (categoria == null) return NotFound("categoria não encontrado");
            return Ok(categoria);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Categoria categoria)
        {
            if (categoria == null) return BadRequest();
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
            return new CreatedAtRouteResult("Obtercategoria", new { id = categoria.Id}, categoria);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, Categoria categoria)
        {
            var categoriaABuscar = await _context.Categorias.FirstOrDefaultAsync(p => p.Id == id);
            if (categoriaABuscar == null) return NotFound();
            _context.Entry(categoria).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(categoria);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var categoria = await _context.Categorias.FirstOrDefaultAsync(p => p.Id == id);
            if (categoria == null) return NotFound("categoria não encontrado");
            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}