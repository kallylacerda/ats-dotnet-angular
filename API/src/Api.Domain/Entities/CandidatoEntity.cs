using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class CandidatoEntity : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string NomeCompleto { get; set; }

        [Required]
        [MaxLength(11)]
        [MinLength(11)]
        public string Cpf { get; set; }

        [Required]
        [MaxLength(60)]
        public string Email { get; set; }

        [MinLength(10)]
        [MaxLength(11)]
        public string Telefone { get; set; }

        public string Descricao { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        public Guid EnderecoId { get; set; }

        public EnderecoEntity Endereco { get; set; }
    }
}
