using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IAlunoRepositorio
    {
        Task<List<AlunoModel>> GetAll();

        Task<AlunoModel> GetById(int id);

        Task<AlunoModel> InsertAluno(AlunoModel aluno);

        Task<AlunoModel> UpdateAluno(AlunoModel aluno, int id);

        Task<bool> DeleteAluno(int id);
    }
}
