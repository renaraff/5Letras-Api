using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepositorio _authRepositorio;

        public AuthController(IAuthRepositorio authRepositorio)
        {
            _authRepositorio = authRepositorio;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<Auth>> Login( [FromBody] Auth requisicao )
        {
            Auth user = await _authRepositorio.Login( requisicao.UsuarioEmail, requisicao.UsuarioSenha );
            return Ok(user);
        }

        
    }
}
