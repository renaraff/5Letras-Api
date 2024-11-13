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
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoRepositorio _alunoRepositorio;

        public AlunoController(IAlunoRepositorio alunoRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
        }

        [HttpGet("GetAllAlunos")]
        public async Task<ActionResult<List<AlunoModel>>> GetAllAlunos()
        {
            List<AlunoModel> alunos = await _alunoRepositorio.GetAll();
            var json = JsonSerializer.Serialize(alunos);
            return Ok(json);
        }

        [HttpGet("GetAlunoId/{id}")]
        public async Task<ActionResult<AlunoModel>> GetAlunoId(int id)
        {
            AlunoModel aluno = await _alunoRepositorio.GetById(id);
            if (aluno == null)
            {
                return NotFound();
            }
            return Ok(aluno);
        }

        [HttpPost("CreateAluno")]
        public async Task<ActionResult<AlunoModel>> InsertAluno([FromBody] AlunoModel alunoModel)
        {
            if (alunoModel == null)
            {
                return BadRequest("Aluno não pode ser nulo.");
            }

            AlunoModel aluno = await _alunoRepositorio.InsertAluno(alunoModel);
            return CreatedAtAction(nameof(GetAlunoId), new { id = aluno.AlunoId }, aluno);
        }

        [HttpPut("UpdateAluno/{id:int}")]
        public async Task<ActionResult<AlunoModel>> UpdateAluno(int id, [FromBody] AlunoModel alunoModel)
        {
            if (alunoModel == null || alunoModel.AlunoId != id)
            {
                return BadRequest("Dados inválidos.");
            }

            AlunoModel aluno = await _alunoRepositorio.UpdateAluno(alunoModel, id);
            if (aluno == null)
            {
                return NotFound();
            }
            return Ok(aluno);
        }

        [HttpDelete("DeleteAluno/{id:int}")]
        public async Task<ActionResult<bool>> DeleteAluno(int id)
        {
            bool deleted = await _alunoRepositorio.DeleteAluno(id);
            if (!deleted)
            {
                return NotFound();
            }
            return Ok(deleted);
        }
    }
}
