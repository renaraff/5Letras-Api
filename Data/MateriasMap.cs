using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class MateriasMap : IEntityTypeConfiguration<MateriasModel>
    {
        public void Configure(EntityTypeBuilder<MateriasModel> builder)
        {
            builder.HasKey(x => x.MateriasId);
            builder.Property(x => x.MateriasNome).IsRequired().HasMaxLength(255);
        }
    }
}
