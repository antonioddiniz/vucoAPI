using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vucoAPI.obj.Models;
using vucoAPI.Data;


namespace vucoAPI.Controllers
{
    [ApiController]
    [Route("v1")]
    public class ProdutoController : ControllerBase
    {
        
        private readonly VucoDbContext _context;

        public ProdutoController(VucoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("produtos")]
        public IActionResult ObterProdutos()
        {
            var produtos = _context.Produtos.ToList();
            return Ok(produtos);
        }

        [HttpGet]
        [Route("produtos/{id}")]
        public IActionResult ObterProdutoPorId(int id)
        {
            var produto = _context.Produtos.Find(id);
            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        [HttpPost]
        [Route("registrarProduto")]
        public IActionResult AdicionarProduto([FromBody] Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterProdutoPorId), new { id = produto.Id }, produto);
        }

        [HttpPut]
        [Route("atualizarProduto/{id}")]
        public IActionResult AtualizarProduto(int id, [FromBody] Produto produto)
        {
            if (id != produto.Id)
            {
                return BadRequest();
            }
            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        [Route("deletarProduto/{id}")]
        public IActionResult DeletarProduto(int id)
        {
            var produto = _context.Produtos.Find(id);
            if (produto == null)
            {
                return NotFound();
            }
            _context.Produtos.Remove(produto);
            _context.SaveChanges();
            return NoContent();
        }


    }
}