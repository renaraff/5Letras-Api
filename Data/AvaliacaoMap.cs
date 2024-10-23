using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class AvaliacaoMap : IEntityTypeConfiguration<AvaliacaoModel>
    {
        public void Configure(EntityTypeBuilder<AvaliacaoModel> builder)
        {
            builder.HasKey(x => x.AvaliacaoId);
            builder.Property(x => x.AlunoId).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ProfessorId).IsRequired().HasMaxLength(255);
            builder.Property(x => x.AvaliacaoDescricao).IsRequired().HasMaxLength(255);
            builder.Property(x => x.AvaliacaoEstrela).IsRequired().HasMaxLength(255);
        }
    }
}
