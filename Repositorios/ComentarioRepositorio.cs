using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api.Repositorios
{
    public class ComentarioRepositorio : IComentarioRepositorio
    {
        private readonly Contexto _dbContext;

        public ComentarioRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ComentarioModel>> GetAll()
        {
            return await _dbContext.Comentario.ToListAsync();
        }

        public async Task<ComentarioModel> GetById(int id)
        {
            return await _dbContext.Comentario.FirstOrDefaultAsync(x => x.ComentarioId == id);
        }

        public async Task<ComentarioModel> InsertComentario(ComentarioModel comentario)
        {
            await _dbContext.Comentario.AddAsync(comentario);
            await _dbContext.SaveChangesAsync();
            return comentario;
        }

        public async Task<ComentarioModel> UpdateComentario(ComentarioModel comentario, int id)
        {
            ComentarioModel comentarios = await GetById(id);
            if (comentarios == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                comentarios.ConteudoId = comentario.ConteudoId;
                comentarios.DuvidaId = comentario.DuvidaId;
                comentarios.ProfessorId = comentario.ProfessorId;
                comentarios.AlunoId = comentario.AlunoId;
                comentarios.ComentarioTexto = comentario.ComentarioTexto;
                _dbContext.Comentario.Update(comentarios);
                await _dbContext.SaveChangesAsync();
            }
            return comentarios;
        }

        public async Task<bool> DeleteComentario(int id)
        {
            ComentarioModel comentarios = await GetById(id);
            if (comentarios == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Comentario.Remove(comentarios);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
