using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api.Repositorios
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private readonly Contexto _dbContext;

        public AlunoRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<AlunoModel>> GetAll()
        {
            return await _dbContext.Aluno.ToListAsync();
        }

        public async Task<AlunoModel> GetById(int id)
        {
            return await _dbContext.Aluno.FirstOrDefaultAsync(x => x.AlunoId == id);
        }

        public async Task<AlunoModel> InsertAluno(AlunoModel aluno)
        {
            await _dbContext.Aluno.AddAsync(aluno);
            await _dbContext.SaveChangesAsync();
            return aluno;
        }

        public async Task<AlunoModel> UpdateAluno(AlunoModel aluno, int id)
        {
            AlunoModel alunos = await GetById(id);
            if (alunos == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                alunos.AlunoNome = aluno.AlunoNome;
                alunos.AlunoEmail = aluno.AlunoEmail;
                alunos.AlunoSenha = aluno.AlunoSenha;
                alunos.AlunoEscolaridade = aluno.AlunoEscolaridade;
                _dbContext.Aluno.Update(alunos);
                await _dbContext.SaveChangesAsync();
            }
            return alunos;
        }

        public async Task<bool> DeleteAluno(int id)
        {
            AlunoModel alunos = await GetById(id);
            if (alunos == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Aluno.Remove(alunos);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
