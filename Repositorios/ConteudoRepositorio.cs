using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api.Repositorios
{
    public class ConteudoRepositorio : IConteudoRepositorio
    {
        private readonly Contexto _dbContext;

        public ConteudoRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ConteudoModel>> GetAll()
        {
            return await _dbContext.Conteudo.ToListAsync();
        }

        public async Task<ConteudoModel> GetById(int id)
        {
            return await _dbContext.Conteudo.FirstOrDefaultAsync(x => x.ConteudoId == id);
        }

        public async Task<ConteudoModel> InsertConteudo(ConteudoModel conteudo)
        {
            await _dbContext.Conteudo.AddAsync(conteudo);
            await _dbContext.SaveChangesAsync();
            return conteudo;
        }

        public async Task<ConteudoModel> UpdateConteudo(ConteudoModel conteudo, int id)
        {
            ConteudoModel conteudos = await GetById(id);
            if (conteudos == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                conteudos.ProfessorId = conteudo.ProfessorId;
                conteudos.MateriasId = conteudo.MateriasId;
                conteudos.ConteudoTexto = conteudos.ConteudoTexto;
                _dbContext.Conteudo.Update(conteudos);
                await _dbContext.SaveChangesAsync();
            }
            return conteudos;
        }

        public async Task<bool> DeleteConteudo(int id)
        {
            ConteudoModel conteudos = await GetById(id); 
            if (conteudos == null) 
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Conteudo.Remove(conteudos);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
