using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class ConteudoMap : IEntityTypeConfiguration<ConteudoModel>
    {
        public void Configure(EntityTypeBuilder<ConteudoModel> builder)
        {
            builder.HasKey(x => x.ConteudoId);
            builder.Property(x => x.ProfessorId).IsRequired().HasMaxLength(255);
            builder.Property(x => x.MateriasId).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ConteudoTexto).IsRequired().HasMaxLength(255);
        }
    }
}
