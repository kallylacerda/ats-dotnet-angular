using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class EnderecoMap : IEntityTypeConfiguration<EnderecoEntity>
    {
        public void Configure(EntityTypeBuilder<EnderecoEntity> builder)
        {
            builder.ToTable("Endereco");

            builder.HasKey(e => e.Id);

            builder.HasIndex(e => e.Cep);

            builder.HasOne(e => e.Municipio)
                    .WithMany(m => m.Enderecos);
        }
    }
}
