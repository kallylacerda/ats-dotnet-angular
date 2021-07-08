using System;
using System.ComponentModel.DataAnnotations;
using Api.Domain.Dtos.Endereco;

namespace Api.Domain.Dtos.Candidato
{
  public class CandidatoDtoCompleto
  {
    public Guid Id { get; set; }
    public string Cpf { get; set; }
    public string NomeCompleto { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Descricao { get; set; }
    public DateTime DataNascimento { get; set; }
    public DateTime CreatedAt { get; set; }
    public EnderecoDto Endereco { get; set; }
  }
}
