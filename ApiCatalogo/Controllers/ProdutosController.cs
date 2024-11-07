using ApiCatalogo.Data;
using ApiCatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly DataContext _context;
        public ProdutosController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var produtos = await _context.Produtos.ToListAsync();
            if (produtos == null) return NotFound();
            return Ok(produtos);
        }
        [HttpGet("{id:int}", Name = "ObterProduto")]
        public async Task<IActionResult> Get(int id)
        {
            var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id);
            if (produto == null) return NotFound("Produto não encontrado");
            return Ok(produto);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Produto produto)
        {
            if (produto == null) return BadRequest();
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return new CreatedAtRouteResult("ObterProduto", new { id = produto.Id}, produto);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, Produto produto)
        {
            var produtoABuscar = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id);
            if (produtoABuscar == null) return NotFound();
            _context.Entry(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(produto);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id);
            if (produto == null) return NotFound("Produto não encontrado");
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}