using System;
using System.Collections.Generic;
using Api.Domain.Dtos.Candidato;

namespace Api.Service.Test.Candidato
{
    public class CandidatoTests
    {
        public static string NomeCompletoCandidato { get; set; }
        public static string EmailCandidato { get; set; }
        public static string NomeCompletoCandidatoUpdated { get; set; }
        public static string EmailCandidatoUpdated { get; set; }
        public static Guid IdCandidato { get; set; }

        public List<CandidatoDto> listCandidatoDto = new List<CandidatoDto>();
        public CandidatoDto CandidatoDto;
        public CandidatoDtoCompleto CandidatoDtoCompleto;
        public CandidatoDtoCreate CandidatoDtoCreate;
        public CandidatoDtoCreateResult CandidatoDtoCreateResult;
        public CandidatoDtoUpdate CandidatoDtoUpdate;
        public CandidatoDtoUpdateResult CandidatoDtoUpdateResult;

        public CandidatoTests()
        {
            IdCandidato = Guid.NewGuid();
            NomeCompletoCandidato = Faker.Name.FullName();
            EmailCandidato = Faker.Internet.Email();
            NomeCompletoCandidatoUpdated = Faker.Name.FullName();
            EmailCandidatoUpdated = Faker.Internet.Email();

            for (int i = 0; i < 10; i++)
            {
                var dto = new CandidatoDto
                {
                    Id = Guid.NewGuid(),
                    NomeCompleto = Faker.Name.FullName(),
                    Email = Faker.Internet.Email()
                };
                listCandidatoDto.Add(dto);
            }

            CandidatoDto = new CandidatoDto
            {
                Id = IdCandidato,
                NomeCompleto = NomeCompletoCandidato,
                Email = EmailCandidato
            };

            CandidatoDtoCompleto = new CandidatoDtoCompleto
            {
                Id = IdCandidato,
                NomeCompleto = NomeCompletoCandidato,
                Email = EmailCandidato
            };

            CandidatoDtoCreate = new CandidatoDtoCreate
            {
                NomeCompleto = NomeCompletoCandidato,
                Email = EmailCandidato
            };

            CandidatoDtoCreateResult = new CandidatoDtoCreateResult
            {
                Id = IdCandidato,
                NomeCompleto = NomeCompletoCandidato,
                Email = EmailCandidato,
                CreatedAt = DateTime.UtcNow
            };

            CandidatoDtoUpdate = new CandidatoDtoUpdate
            {
                Id = IdCandidato,
                NomeCompleto = NomeCompletoCandidatoUpdated,
                Email = EmailCandidatoUpdated
            };

            CandidatoDtoUpdateResult = new CandidatoDtoUpdateResult
            {
                Id = IdCandidato,
                NomeCompleto = NomeCompletoCandidatoUpdated,
                Email = EmailCandidatoUpdated,
                UpdatedAt = DateTime.UtcNow
            };
        }
    }
}
