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
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorRepositorio _professorRepositorio;

        public ProfessorController(IProfessorRepositorio professorRepositorio)
        {
            _professorRepositorio = professorRepositorio;
        }

        [HttpGet("GetAllProfessores")]
        public async Task<ActionResult<List<ProfessorModel>>> GetAllProfessores()
        {
            List<ProfessorModel> professores = await _professorRepositorio.GetAll();
            var json = JsonSerializer.Serialize(professores);
            return Ok(json);
        }

        [HttpGet("GetProfessorId/{id}")]
        public async Task<ActionResult<ProfessorModel>> GetProfessorId(int id)
        {
            ProfessorModel professor = await _professorRepositorio.GetById(id);
            if (professor == null)
            {
                return NotFound();
            }
            return Ok(professor);
        }

        [HttpPost("CreateProfessor")]
        public async Task<ActionResult<ProfessorModel>> InsertProfessor([FromBody] ProfessorModel professorModel)
        {
            if (professorModel == null)
            {
                return BadRequest("Professor não pode ser nulo.");
            }

            ProfessorModel professor = await _professorRepositorio.InsertProfessor(professorModel);
            return CreatedAtAction(nameof(GetProfessorId), new { id = professor.ProfessorId }, professor);
        }

        [HttpPut("UpdateProfessor/{id:int}")]
        public async Task<ActionResult<ProfessorModel>> UpdateProfessor(int id, [FromBody] ProfessorModel professorModel)
        {
            if (professorModel == null || professorModel.ProfessorId != id)
            {
                return BadRequest("Dados inválidos.");
            }

            ProfessorModel professor = await _professorRepositorio.UpdateProfessor(professorModel, id);
            if (professor == null)
            {
                return NotFound();
            }
            return Ok(professor);
        }

        [HttpDelete("DeleteProfessor/{id:int}")]
        public async Task<ActionResult<bool>> DeleteProfessor(int id)
        {
            bool deleted = await _professorRepositorio.DeleteProfessor(id);
            if (!deleted)
            {
                return NotFound();
            }
            return Ok(deleted);
        }
    }
}
