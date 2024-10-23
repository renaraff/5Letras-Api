using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IProfessorRepositorio
    {
        Task<List<ProfessorModel>> GetAll();

        Task<ProfessorModel> GetById(int id);

        Task<ProfessorModel> InsertProfessor(ProfessorModel professor);

        Task<ProfessorModel> UpdateProfessor(ProfessorModel professor, int id);

        Task<bool> DeleteProfessor(int id);
    }
}
