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
    public class MateriasController : ControllerBase
    {
        private readonly IMateriasRepositorio _materiasRepositorio;

        public MateriasController(IMateriasRepositorio materiasRepositorio)
        {
            _materiasRepositorio = materiasRepositorio;
        }

        [HttpGet("GetAllMaterias")]
        public async Task<ActionResult<List<MateriasModel>>> GetAllMaterias()
        {
            List<MateriasModel> materias = await _materiasRepositorio.GetAll();
            var json = JsonSerializer.Serialize(materias);
            return Ok(json);
        }

        [HttpGet("GetMateriasId/{id}")]
        public async Task<ActionResult<MateriasModel>> GetMateriasId(int id)
        {
            MateriasModel materia = await _materiasRepositorio.GetById(id);
            if (materia == null)
            {
                return NotFound();
            }
            return Ok(materia);
        }

        [HttpPost("CreateMaterias")]
        public async Task<ActionResult<MateriasModel>> InsertMateria([FromBody] MateriasModel materiasModel)
        {
            if (materiasModel == null)
            {
                return BadRequest("Matéria não pode ser nula.");
            }

            MateriasModel materia = await _materiasRepositorio.InsertMaterias(materiasModel);
            return CreatedAtAction(nameof(GetMateriasId), new { id = materia.MateriasId }, materia);
        }

        [HttpPut("UpdateMaterias/{id:int}")]
        public async Task<ActionResult<MateriasModel>> UpdateMaterias(int id, [FromBody] MateriasModel materiasModel)
        {
            if (materiasModel == null || materiasModel.MateriasId != id)
            {
                return BadRequest("Dados inválidos.");
            }

            MateriasModel materia = await _materiasRepositorio.UpdateMaterias(materiasModel, id);
            if (materia == null)
            {
                return NotFound();
            }
            return Ok(materia);
        }

        [HttpDelete("DeleteMaterias/{id:int}")]
        public async Task<ActionResult<bool>> DeleteMaterias(int id)
        {
            bool deleted = await _materiasRepositorio.DeleteMaterias(id);
            if (!deleted)
            {
                return NotFound();
            }
            return Ok(deleted);
        }
    }
}
