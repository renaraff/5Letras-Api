using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api.Repositorios
{
    public class AuthRepositorio : IAuthRepositorio
    {
        private readonly Contexto _dbContext;

        public AuthRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Auth> Login( string email , string senha )
        {
            AlunoModel aluno;
            ProfessorModel professor;
            aluno = await _dbContext.Aluno.FirstOrDefaultAsync( a => a.AlunoEmail == email && a.AlunoSenha == senha );
            if (aluno == null )
            {
                professor = await _dbContext.Professor.FirstOrDefaultAsync( p => p.ProfessorEmail == email && p.ProfessorSenha == senha );
                if( professor != null )
                {
                    return new Auth
                    {
                        UsuarioId = professor.ProfessorId,
                        UsuarioNome = professor.ProfessorNome,
                        UsuarioTipo = "professor",
                        UsuarioEmail = professor.ProfessorEmail,
                        UsuarioSenha = ""
                    };
                } else
                {
                    return new Auth { };
                }
            } else
            {
                return new Auth
                {
                    UsuarioId = aluno.AlunoId,
                    UsuarioNome = aluno.AlunoNome,
                    UsuarioTipo = "aluno",
                    UsuarioEmail = aluno.AlunoEmail,
                    UsuarioSenha = ""
                };
            }
        }
    }
}
