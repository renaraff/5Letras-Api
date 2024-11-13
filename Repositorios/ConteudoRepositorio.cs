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

        public async Task<List<ConteudoCompleto>> GetAll()
        {
            return await _dbContext.Conteudo
                .Join( _dbContext.Professor , 
                    conteudo => conteudo.ProfessorId,
                    professor => professor.ProfessorId,
                    ( conteudo, professor ) => new { conteudo, professor } )
                .Join( _dbContext.Materias ,
                    conteudo => conteudo.conteudo.MateriasId,
                    materias => materias.MateriasId,
                    ( conteudo, materias ) => new ConteudoCompleto
                    {
                        ConteudoId = conteudo.conteudo.ConteudoId,
                        ProfessorNome = conteudo.professor.ProfessorNome,
                        ProfessorId = conteudo.professor.ProfessorId,
                        Materia = new MateriasModel
                        {
                            MateriasId = materias.MateriasId,
                            MateriasNome =  materias.MateriasNome
                        },
                        ConteudoTexto = conteudo.conteudo.ConteudoTexto
                    }
                )
                .ToListAsync();
        }

        public async Task<ConteudoCompleto> GetConteudoById(int id)
        {
            return await _dbContext.Conteudo
                .Join(_dbContext.Professor,
                    conteudo => conteudo.ProfessorId,
                    professor => professor.ProfessorId,
                    (conteudo, professor) => new { conteudo, professor })
                .Join(_dbContext.Materias,
                    conteudo => conteudo.conteudo.MateriasId,
                    materias => materias.MateriasId,
                    (conteudo, materias) => new ConteudoCompleto
                    {
                        ConteudoId = conteudo.conteudo.ConteudoId,
                        ProfessorNome = conteudo.professor.ProfessorNome,
                        ProfessorId = conteudo.professor.ProfessorId,
                        Materia = new MateriasModel
                        {
                            MateriasId = materias.MateriasId,
                            MateriasNome = materias.MateriasNome
                        },
                        ConteudoTexto = conteudo.conteudo.ConteudoTexto
                    }
                )
                .FirstOrDefaultAsync(x => x.ConteudoId == id);
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
