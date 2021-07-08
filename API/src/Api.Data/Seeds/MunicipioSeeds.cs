using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Seeds
{
    public class MunicipioSeeds
    {
        public static void Municipios(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MunicipioEntity>().HasData(
                new MunicipioEntity
                {
                    Id = 1,
                    Nome = "Brasília",
                    UfId = 1
                },
                new MunicipioEntity
                {
                    Id = 2,
                    Nome = "João Pessoa",
                    UfId = 2
                },
                new MunicipioEntity
                {
                    Id = 3,
                    Nome = "Campina Grande",
                    UfId = 2
                },
                new MunicipioEntity
                {
                    Id = 4,
                    Nome = "São Paulo",
                    UfId = 3
                },
                new MunicipioEntity
                {
                    Id = 5,
                    Nome = "São Bernardo do Campo",
                    UfId = 3
                },
                new MunicipioEntity
                {
                    Id = 6,
                    Nome = "Jundiaí",
                    UfId = 3
                },
                new MunicipioEntity
                {
                    Id = 7,
                    Nome = "Campinas",
                    UfId = 3
                }
            );
        }
    }
}
