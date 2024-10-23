using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IConteudoRepositorio
    {
        Task<List<ConteudoModel>> GetAll();

        Task<ConteudoModel> GetById(int id);

        Task<ConteudoModel> InsertConteudo(ConteudoModel conteudo);

        Task<ConteudoModel> UpdateConteudo(ConteudoModel conteudo, int id);

        Task<bool> DeleteConteudo(int id);
    }
}
