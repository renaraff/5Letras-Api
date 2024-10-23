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
    public class ConteudoController : ControllerBase
    {
        private readonly IConteudoRepositorio _conteudoRepositorio;

        public ConteudoController(IConteudoRepositorio conteudoRepositorio)
        {
            _conteudoRepositorio = conteudoRepositorio;
        }

        [HttpGet("GetAllConteudos")]
        public async Task<ActionResult<List<ConteudoModel>>> GetAllConteudos()
        {
            List<ConteudoModel> conteudos = await _conteudoRepositorio.GetAll();
            var json = JsonSerializer.Serialize(conteudos);
            return Ok(json);
        }

        [HttpGet("GetConteudoId/{id}")]
        public async Task<ActionResult<ConteudoModel>> GetConteudoId(int id)
        {
            ConteudoModel conteudo = await _conteudoRepositorio.GetById(id);
            if (conteudo == null)
            {
                return NotFound();
            }
            return Ok(conteudo);
        }

        [HttpPost("CreateConteudo")]
        public async Task<ActionResult<ConteudoModel>> InsertConteudo([FromBody] ConteudoModel conteudoModel)
        {
            if (conteudoModel == null)
            {
                return BadRequest("Conteúdo não pode ser nulo.");
            }

            ConteudoModel conteudo = await _conteudoRepositorio.InsertConteudo(conteudoModel);
            return CreatedAtAction(nameof(GetConteudoId), new { id = conteudo.ConteudoId }, conteudo);
        }

        [HttpPut("UpdateConteudo/{id:int}")]
        public async Task<ActionResult<ConteudoModel>> UpdateConteudo(int id, [FromBody] ConteudoModel conteudoModel)
        {
            if (conteudoModel == null || conteudoModel.ConteudoId != id)
            {
                return BadRequest("Dados inválidos.");
            }

            ConteudoModel conteudo = await _conteudoRepositorio.UpdateConteudo(conteudoModel, id);
            if (conteudo == null)
            {
                return NotFound();
            }
            return Ok(conteudo);
        }

        [HttpDelete("DeleteConteudo/{id:int}")]
        public async Task<ActionResult<bool>> DeleteConteudo(int id)
        {
            bool deleted = await _conteudoRepositorio.DeleteConteudo(id);
            if (!deleted)
            {
                return NotFound();
            }
            return Ok(deleted);
        }
    }
}
