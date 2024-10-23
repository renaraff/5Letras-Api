using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class ComentarioMap : IEntityTypeConfiguration<ComentarioModel>
    {
        public void Configure(EntityTypeBuilder<ComentarioModel> builder)
        {
            builder.HasKey(x => x.ComentarioId);
            builder.Property(x => x.ConteudoId).IsRequired().HasMaxLength(255);
            builder.Property(x => x.DuvidaId).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ProfessorId).IsRequired().HasMaxLength(255);
            builder.Property(x => x.AlunoId).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ComentarioTexto).IsRequired().HasMaxLength(255);
        }
    }
}
