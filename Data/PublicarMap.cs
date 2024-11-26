using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class PublicarMap : IEntityTypeConfiguration<PublicarModel>
    {
        public void Configure(EntityTypeBuilder<PublicarModel> builder)
        {
            builder.HasKey(x => x.PublicarId);
            builder.Property(x => x.UsuarioId).IsRequired().HasMaxLength(255);
            builder.Property(x => x.MateriaId).IsRequired().HasMaxLength(255);
            builder.Property(x => x.PublicarTexto).IsRequired().HasMaxLength(255);
           
        }
    }
}