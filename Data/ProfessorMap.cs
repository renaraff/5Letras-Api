using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class ProfessorMap : IEntityTypeConfiguration<ProfessorModel>
    {
        public void Configure(EntityTypeBuilder<ProfessorModel> builder)
        {
            builder.HasKey(x => x.ProfessorId);
            builder.Property(x => x.ProfessorNome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ProfessorEmail).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ProfessorSenha).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ProfessorGraduacao).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ProfessorDescricao).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ProfessorOcupacao).IsRequired().HasMaxLength(255);
        }
    }
}
