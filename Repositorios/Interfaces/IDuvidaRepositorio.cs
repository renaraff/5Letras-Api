using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IDuvidaRepositorio
    {
        Task<List<DuvidaModel>> GetAll();

        Task<DuvidaModel> GetById(int id);

        Task<DuvidaModel> InsertDuvida(DuvidaModel duvida);

        Task<DuvidaModel> UpdateDuvida(DuvidaModel duvida, int id);

        Task<bool> DeleteDuvida(int id);
    }
}
