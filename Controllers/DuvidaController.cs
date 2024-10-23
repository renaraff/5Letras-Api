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
    public class DuvidaController : ControllerBase
    {
        private readonly IDuvidaRepositorio _duvidaRepositorio;

        public DuvidaController(IDuvidaRepositorio duvidaRepositorio)
        {
            _duvidaRepositorio = duvidaRepositorio;
        }

        [HttpGet("GetAllDuvidas")]
        public async Task<ActionResult<List<DuvidaModel>>> GetAllDuvidas()
        {
            List<DuvidaModel> duvidas = await _duvidaRepositorio.GetAll();
            var json = JsonSerializer.Serialize(duvidas);
            return Ok(json);
        }

        [HttpGet("GetDuvidaId/{id}")]
        public async Task<ActionResult<DuvidaModel>> GetDuvidaId(int id)
        {
            DuvidaModel duvida = await _duvidaRepositorio.GetById(id);
            if (duvida == null)
            {
                return NotFound();
            }
            return Ok(duvida);
        }

        [HttpPost("CreateDuvida")]
        public async Task<ActionResult<DuvidaModel>> InsertDuvida([FromBody] DuvidaModel duvidaModel)
        {
            if (duvidaModel == null)
            {
                return BadRequest("Dúvida não pode ser nula.");
            }

            DuvidaModel duvida = await _duvidaRepositorio.InsertDuvida(duvidaModel);
            return CreatedAtAction(nameof(GetDuvidaId), new { id = duvida.DuvidaId }, duvida);
        }

        [HttpPut("UpdateDuvida/{id:int}")]
        public async Task<ActionResult<DuvidaModel>> UpdateDuvida(int id, [FromBody] DuvidaModel duvidaModel)
        {
            if (duvidaModel == null || duvidaModel.DuvidaId != id)
            {
                return BadRequest("Dados inválidos.");
            }

            DuvidaModel duvida = await _duvidaRepositorio.UpdateDuvida(duvidaModel, id);
            if (duvida == null)
            {
                return NotFound();
            }
            return Ok(duvida);
        }

        [HttpDelete("DeleteDuvida/{id:int}")]
        public async Task<ActionResult<bool>> DeleteDuvida(int id)
        {
            bool deleted = await _duvidaRepositorio.DeleteDuvida(id);
            if (!deleted)
            {
                return NotFound();
            }
            return Ok(deleted);
        }
    }
}
