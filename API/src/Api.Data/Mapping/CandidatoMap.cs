using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class CandidatoMap : IEntityTypeConfiguration<CandidatoEntity>
    {
        public void Configure(EntityTypeBuilder<CandidatoEntity> builder)
        {
            builder.ToTable("Candidato");

            builder.HasKey(c => c.Id);

            builder.HasIndex(c => c.Cpf)
                    .IsUnique();

            builder.HasIndex(c => c.Email)
                    .IsUnique();

            builder.HasOne(c => c.Endereco);
        }
    }
}
