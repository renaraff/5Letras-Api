using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api.Repositorios
{
    public class DuvidaRepositorio : IDuvidaRepositorio
    {
        private readonly Contexto _dbContext;

        public DuvidaRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<DuvidaModel>> GetAll()
        {
            return await _dbContext.Duvida.ToListAsync();
        }

        public async Task<DuvidaModel> GetById(int id)
        {
            return await _dbContext.Duvida.FirstOrDefaultAsync(x => x.DuvidaId == id);
        }

        public async Task<DuvidaModel> InsertDuvida(DuvidaModel duvida)
        {
            await _dbContext.Duvida.AddAsync(duvida);
            await _dbContext.SaveChangesAsync();
            return duvida;
        }

        public async Task<DuvidaModel> UpdateDuvida(DuvidaModel duvida, int id)
        {
            DuvidaModel duvidas = await GetById(id);
            if (duvidas == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                duvidas.AlunoId = duvida.AlunoId;
                duvidas.MateriasId = duvida.MateriasId;
                duvidas.DuvidaTexto = duvida.DuvidaTexto;
                _dbContext.Duvida.Update(duvida);
                await _dbContext.SaveChangesAsync();
            }
            return duvida;
        }

        public async Task<bool> DeleteDuvida(int id)
        {
            DuvidaModel duvidas = await GetById(id);
            if (duvidas == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Duvida.Remove(duvidas);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
