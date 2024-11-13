using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api.Repositorios
{
    public class AvaliacaoRepositorio : IAvaliacaoRepositorio
    {
    private readonly Contexto _dbContext;

        public AvaliacaoRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<AvaliacaoModel>> GetAll()
        {
            return await _dbContext.Avaliacao.ToListAsync();
        }

        public async Task<AvaliacaoModel> GetById(int id)
        {
            return await _dbContext.Avaliacao.FirstOrDefaultAsync(x => x.AvaliacaoId == id);
        }

        public async Task<AvaliacaoModel> InsertAvaliacao(AvaliacaoModel avaliacoes)
        {
            await _dbContext.Avaliacao.AddAsync(avaliacoes);
            await _dbContext.SaveChangesAsync();
            return avaliacoes;
        }

        public async Task<AvaliacaoModel> UpdateAvaliacao(AvaliacaoModel avaliacoes, int id)
        {
            AvaliacaoModel avaliacao = await GetById(id);
            if (avaliacao == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                avaliacao.AlunoId = avaliacoes.AlunoId;
                avaliacao.ProfessorId = avaliacoes.ProfessorId;
                avaliacao.AvaliacaoDescricao = avaliacoes.AvaliacaoDescricao;
                avaliacao.AvaliacaoEstrela = avaliacoes.AvaliacaoEstrela;
                _dbContext.Avaliacao.Update(avaliacao);
                await _dbContext.SaveChangesAsync();
            }
            return avaliacao;
        }

        public async Task<bool> DeleteAvaliacao(int id)
        {
            AvaliacaoModel avaliacao = await GetById(id);
            if (avaliacao == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Avaliacao.Remove(avaliacao);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}