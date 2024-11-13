using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IAvaliacaoRepositorio
    {
        Task<List<AvaliacaoModel>> GetAll();

        Task<AvaliacaoModel> GetById(int id);

        Task<AvaliacaoModel> InsertAvaliacao(AvaliacaoModel avaliacoes);

        Task<AvaliacaoModel> UpdateAvaliacao(AvaliacaoModel avaliacoes, int id);

        Task<bool> DeleteAvaliacao(int id);
    }
}
