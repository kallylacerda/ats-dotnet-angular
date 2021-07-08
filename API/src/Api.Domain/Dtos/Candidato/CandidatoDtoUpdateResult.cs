using System;

namespace Api.Domain.Dtos.Candidato
{
    public class CandidatoDtoUpdateResult
    {
        public Guid Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
