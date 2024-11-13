using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class AlunoMap : IEntityTypeConfiguration<AlunoModel>
    {
        public void Configure(EntityTypeBuilder<AlunoModel> builder)
        {
            builder.HasKey(x => x.AlunoId);
            builder.Property(x => x.AlunoNome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.AlunoEmail).IsRequired().HasMaxLength(255);
            builder.Property(x => x.AlunoSenha).IsRequired().HasMaxLength(255);
            builder.Property(x => x.AlunoEscolaridade).IsRequired().HasMaxLength(255);
        }
    }
}
