using System;
using System.ComponentModel.DataAnnotations;
using Api.Domain.Dtos.Endereco;
using Api.Domain.Validations;

namespace Api.Domain.Dtos.Candidato
{
  public class CandidatoDtoCreate
  {
    [Required(ErrorMessage = "CPF é campo obrigatório")]
    [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve ter {1} caracteres")]
    [OnlyNumber(ErrorMessage = "CPF deve conter apenas números")]
    public string Cpf { get; set; }

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
    [OnlyNumber(ErrorMessage = "Telefone deve conter apenas números")]
    public string Telefone { get; set; }

    [StringLength(1000, ErrorMessage = "A descrição deve ter no máximo {1} caracteres")]
    public string Descricao { get; set; }

    [Required(ErrorMessage = "Data de nascimento é campo obrigatório")]
    [DataType(DataType.Date, ErrorMessage = "Formato de data inválido")]
    [Birthdate(ErrorMessage = "Data de nascimento não pode ser maior ou igual a data de hoje")]
    public DateTime DataNascimento { get; set; }

    public EnderecoDtoCreate Endereco { get; set; }
  }
}
