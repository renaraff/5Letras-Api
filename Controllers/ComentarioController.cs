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
    public class ComentarioController : ControllerBase
    {
        private readonly IComentarioRepositorio _comentarioRepositorio;

        public ComentarioController(IComentarioRepositorio comentarioRepositorio)
        {
            _comentarioRepositorio = comentarioRepositorio;
        }

        [HttpGet("GetAllComentarios")]
        public async Task<ActionResult<List<ComentarioModel>>> GetAllComentarios()
        {
            List<ComentarioModel> comentarios = await _comentarioRepositorio.GetAll();
            var json = JsonSerializer.Serialize(comentarios);
            return Ok(json);
        }

        [HttpGet("GetComentarioId/{id}")]
        public async Task<ActionResult<ComentarioModel>> GetComentarioId(int id)
        {
            ComentarioModel comentario = await _comentarioRepositorio.GetById(id);
            if (comentario == null)
            {
                return NotFound();
            }
            return Ok(comentario);
        }

        [HttpPost("CreateComentario")]
        public async Task<ActionResult<ComentarioModel>> InsertComentario([FromBody] ComentarioModel comentarioModel)
        {
            if (comentarioModel == null)
            {
                return BadRequest("Comentário não pode ser nulo.");
            }

            ComentarioModel comentario = await _comentarioRepositorio.InsertComentario(comentarioModel);
            return CreatedAtAction(nameof(GetComentarioId), new { id = comentario.ComentarioId }, comentario);
        }

        [HttpPut("UpdateComentario/{id:int}")]
        public async Task<ActionResult<ComentarioModel>> UpdateComentario(int id, [FromBody] ComentarioModel comentarioModel)
        {
            if (comentarioModel == null || comentarioModel.ComentarioId != id)
            {
                return BadRequest("Dados inválidos.");
            }

            ComentarioModel comentario = await _comentarioRepositorio.UpdateComentario(comentarioModel, id);
            if (comentario == null)
            {
                return NotFound();
            }
            return Ok(comentario);
        }

        [HttpDelete("DeleteComentario/{id:int}")]
        public async Task<ActionResult<bool>> DeleteComentario(int id)
        {
            bool deleted = await _comentarioRepositorio.DeleteComentario(id);
            if (!deleted)
            {
                return NotFound();
            }
            return Ok(deleted);
        }
    }
}
