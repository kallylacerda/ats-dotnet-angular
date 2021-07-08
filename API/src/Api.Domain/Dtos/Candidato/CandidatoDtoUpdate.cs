using System;
using System.ComponentModel.DataAnnotations;
using Api.Domain.Dtos.Endereco;

namespace Api.Domain.Dtos.Candidato
{
    public class CandidatoDtoUpdate
    {
        [Required(ErrorMessage = "Id é campo obrigatório.")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Nome é campo obrigatório")]
        [StringLength(100, ErrorMessage = "O nome completo deve ter no máximo {1} caracteres")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "E-mail é campo obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido")]
        [StringLength(100, ErrorMessage = "E-mail deve ter no máximo {1} caracteres")]
        public string Email { get; set; }

        [StringLength(11,
            MinimumLength = 10,
            ErrorMessage = "Telefone deve ter no máximo {1} caracteres e no mínimo {2} caracteres"
        )]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Data de nascimento é campo obrigatório")]
        [DataType(DataType.Date, ErrorMessage = "Formato de data inválido")]
        public DateTime DataNascimento { get; set; }

        public EnderecoDtoUpdate Endereco { get; set; }
    }
}
