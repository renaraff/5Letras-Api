using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api.Repositorios
{
    public class ProfessorRepositorio : IProfessorRepositorio
    {
        private readonly Contexto _dbContext;

        public ProfessorRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ProfessorModel>> GetAll()
        {
            return await _dbContext.Professor.ToListAsync();
        }

        public async Task<ProfessorModel> GetById(int id)
        {
            return await _dbContext.Professor.FirstOrDefaultAsync(x => x.ProfessorId == id);
        }

        public async Task<ProfessorModel> InsertProfessor(ProfessorModel professor)
        {
            await _dbContext.Professor.AddAsync(professor);
            await _dbContext.SaveChangesAsync();
            return professor;
        }

        public async Task<ProfessorModel> UpdateProfessor(ProfessorModel professor, int id)
        {
            ProfessorModel professores = await GetById(id);
            if (professores == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                professores.ProfessorNome = professor.ProfessorNome;
                professores.ProfessorEmail = professor.ProfessorEmail;
                professores.ProfessorSenha = professor.ProfessorSenha;
                professores.ProfessorGraduacao = professor.ProfessorGraduacao;
                professores.ProfessorDescricao = professor.ProfessorDescricao;
                professores.ProfessorOcupacao = professor.ProfessorOcupacao;
                _dbContext.Professor.Update(professor);
                await _dbContext.SaveChangesAsync();
            }
            return professor;
        }

        public async Task<bool> DeleteProfessor(int id)
        {
            ProfessorModel professores = await GetById(id);
            if (professores == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Professor.Remove(professores);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
