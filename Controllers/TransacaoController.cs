using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vucoAPI.Data;
using vucoAPI.obj.Models;

namespace vucoAPI.Controllers
{
    [ApiController]
    [Route("v1")]
    public class TransacaoController : ControllerBase
    {
        private readonly VucoDbContext _context;

        public TransacaoController(VucoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("transacoes")]
        public IActionResult ObterTransacoes()
        {
            var transacoes = _context.Transacoes.ToList();
            return Ok(transacoes);
        }

        [HttpGet]
        [Route("transacoes/{id}")]
        public IActionResult ObterTransacaoPorId(int id)
        {
            var transacao = _context.Transacoes.Find(id);
            if (transacao == null)
            {
                return NotFound();
            }
            return Ok(transacao);
        }

        [HttpPost]
        [Route("registrarTransacao")]
        public IActionResult AdicionarTransacao([FromBody] Transacao transacao)
        {
            _context.Transacoes.Add(transacao);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterTransacaoPorId), new { id = transacao.Id }, transacao);
        }

        [HttpPut]
        [Route("atualizarTransacao/{id}")]
        public IActionResult AtualizarTransacao(int id, [FromBody] Transacao transacao)
        {
            if (id != transacao.Id)
            {
                return BadRequest();
            }
            _context.Entry(transacao).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        [Route("deletarTransacao/{id}")]
        public IActionResult DeletarTransacao(int id)
        {
            var transacao = _context.Transacoes.Find(id);
            if (transacao == null)
            {
                return NotFound();
            }
            _context.Transacoes.Remove(transacao);
            _context.SaveChanges();
            return NoContent();
    }
}}