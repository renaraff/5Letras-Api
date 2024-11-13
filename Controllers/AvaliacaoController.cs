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
    public class AvaliacaoController : ControllerBase
    {
        private readonly IAvaliacaoRepositorio _avaliacaoRepositorio;

        public AvaliacaoController(IAvaliacaoRepositorio avaliacaoRepositorio)
        {
            _avaliacaoRepositorio = avaliacaoRepositorio;
        }

        [HttpGet("GetAllAvaliacao")]
        public async Task<ActionResult<List<AvaliacaoModel>>> GetAllAvaliacao()
        {
            List<AvaliacaoModel> avaliacao = await _avaliacaoRepositorio.GetAll();
            var json = JsonSerializer.Serialize(avaliacao);
            return Ok(json);
        }

        [HttpGet("GetAvaliacaoId/{id}")]
        public async Task<ActionResult<AvaliacaoModel>> GetAvaliacaoId(int id)
        {
            AvaliacaoModel avaliacao = await _avaliacaoRepositorio.GetById(id);
            if (avaliacao == null)
            {
                return NotFound();
            }
            return Ok(avaliacao);
        }

        [HttpPost("CreateAvaliacao")]
        public async Task<ActionResult<AvaliacaoModel>> InsertAvaliacao([FromBody] AvaliacaoModel avaliacaoModel)
        {
            if (avaliacaoModel == null)
            {
                return BadRequest("Avaliação não pode ser nula.");
            }

            AvaliacaoModel avaliacao = await _avaliacaoRepositorio.InsertAvaliacao(avaliacaoModel);
            return CreatedAtAction(nameof(GetAvaliacaoId), new { id = avaliacao.AvaliacaoId }, avaliacao);
        }

        [HttpPut("UpdateAvaliacao/{id:int}")]
        public async Task<ActionResult<AvaliacaoModel>> UpdateAvaliacao(int id, [FromBody] AvaliacaoModel avaliacaoModel)
        {
            if (avaliacaoModel == null || avaliacaoModel.AvaliacaoId != id)
            {
                return BadRequest("Dados inválidos.");
            }

            AvaliacaoModel avaliacao = await _avaliacaoRepositorio.UpdateAvaliacao(avaliacaoModel, id);
            if (avaliacao == null)
            {
                return NotFound();
            }
            return Ok(avaliacao);
        }

        [HttpDelete("DeleteAvaliacao/{id:int}")]
        public async Task<ActionResult<bool>> DeleteAvaliacao(int id)
        {
            bool deleted = await _avaliacaoRepositorio.DeleteAvaliacao(id);
            if (!deleted)
            {
                return NotFound();
            }
            return Ok(deleted);
        }
    }
}
