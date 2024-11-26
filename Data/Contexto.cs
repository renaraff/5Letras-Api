using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }
        public DbSet<AlunoModel> Aluno { get; set; }
        public DbSet<ComentarioModel> Comentario { get; set; }
        public DbSet<ConteudoModel> Conteudo { get; set; }
        public DbSet<DuvidaModel> Duvida { get; set; }
        public DbSet<MateriasModel> Materias { get; set; }
        public DbSet<ProfessorModel> Professor { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoMap());
            modelBuilder.ApplyConfiguration(new ComentarioMap());
            modelBuilder.ApplyConfiguration(new ConteudoMap());
            modelBuilder.ApplyConfiguration(new DuvidaMap());
            modelBuilder.ApplyConfiguration(new MateriasMap());
            modelBuilder.ApplyConfiguration(new ProfessorMap());
            base.OnModelCreating(modelBuilder);
        }

    }
}