using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class DuvidaMap : IEntityTypeConfiguration<DuvidaModel>
    {
        public void Configure(EntityTypeBuilder<DuvidaModel> builder)
        {
            builder.HasKey(x => x.DuvidaId);
            builder.Property(x => x.AlunoId).IsRequired().HasMaxLength(255);
            builder.Property(x => x.MateriasId).IsRequired().HasMaxLength(255);
            builder.Property(x => x.DuvidaTexto).IsRequired().HasMaxLength(255);
        }
    }
}
