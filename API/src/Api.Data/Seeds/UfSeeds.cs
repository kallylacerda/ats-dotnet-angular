using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Seeds
{
    public static class UfSeeds
    {
        public static void Ufs(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UfEntity>().HasData(
                new UfEntity
                {
                    Id = 1,
                    Sigla = "DF",
                    Nome = "Distrito Federal"
                },
                new UfEntity
                {
                    Id = 2,
                    Sigla = "PB",
                    Nome = "Paraíba"
                },
                new UfEntity
                {
                    Id = 3,
                    Sigla = "SP",
                    Nome = "São Paulo"
                }
            );
        }
    }
}
