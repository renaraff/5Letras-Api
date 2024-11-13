using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IComentarioRepositorio
    {
        Task<List<ComentarioModel>> GetAll();

        Task<ComentarioModel> GetById(int id);

        Task<ComentarioModel> InsertComentario(ComentarioModel comentario);

        Task<ComentarioModel> UpdateComentario(ComentarioModel comentario, int id);

        Task<bool> DeleteComentario(int id);
    }
}
