using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vucoAPI.Data;
using vucoAPI.Models;
using vucoAPI.Services;

namespace vucoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly VucoDbContext _context;

        public AuthController(IConfiguration configuration, VucoDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == loginModel.Email && u.Senha == loginModel.Senha);

            if (usuario == null)
            {
                return Unauthorized(new { message = "Email ou senha do usuário inválido" });
            }

            var token = TokenService.GenerateToken(usuario);
            return Ok(new { token });
        }

    }
}