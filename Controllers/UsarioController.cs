using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vucoAPI.obj.Models;
using vucoAPI.Data;
using Microsoft.AspNetCore.Authorization;

namespace vucoAPI.Controllers
{
    [ApiController]
    [Route("v1")]
    public class UsarioController : ControllerBase
    {
        private readonly VucoDbContext _context;

        public UsarioController(VucoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("usuarios")]
        [Authorize]

        public IActionResult ObterUsuarios()
        {
            var usuarios = _context.Usuarios.ToList();
            return Ok(usuarios);
        }

        [HttpGet]
        [Route("usuarios/{id}")]
        public IActionResult ObterUsuarioPorId(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost]
        [Route("registrarUsuario")]
        public IActionResult AdicionarUsuario([FromBody] Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterUsuarioPorId), new { id = usuario.Id }, usuario);
        }

        [HttpPut]
        [Route("atualizarUsuario/{id}")]
        public IActionResult AtualizarUsuario(int id, [FromBody] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }
            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        [Route("deletarUsuario/{id}")]
        public IActionResult DeletarUsuario(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
            return NoContent();
        }

    }
}