using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IMateriasRepositorio
    {
        Task<List<MateriasModel>> GetAll();

        Task<MateriasModel> GetById(int id);

        Task<MateriasModel> InsertMaterias(MateriasModel materias);

        Task<MateriasModel> UpdateMaterias(MateriasModel materias, int id);

        Task<bool> DeleteMaterias(int id);
    }
}
