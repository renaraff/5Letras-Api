using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api.Repositorios
{
    public class MateriasRepositorio : IMateriasRepositorio
    {
        private readonly Contexto _dbContext;

        public MateriasRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<MateriasModel>> GetAll()
        {
            return await _dbContext.Materias.ToListAsync();
        }

        public async Task<MateriasModel> GetById(int id)
        {
            return await _dbContext.Materias.FirstOrDefaultAsync(x => x.MateriasId == id);
        }

        public async Task<MateriasModel> InsertMaterias(MateriasModel materias)
        {
            await _dbContext.Materias.AddAsync(materias);
            await _dbContext.SaveChangesAsync();
            return materias;
        }

        public async Task<MateriasModel> UpdateMaterias(MateriasModel materias, int id)
        {
            MateriasModel materia = await GetById(id);
            if (materia == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                materia.MateriasNome = materias.MateriasNome;
                _dbContext.Materias.Update(materia);
                await _dbContext.SaveChangesAsync();
            }
            return materia;
        }

        public async Task<bool> DeleteMaterias(int id)
        {
            MateriasModel materia = await GetById(id);
            if (materia == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Materias.Remove(materia);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
