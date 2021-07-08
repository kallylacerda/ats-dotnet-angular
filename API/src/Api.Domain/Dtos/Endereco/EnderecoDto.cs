using System;
using Api.Domain.Dtos.Municipio;

namespace Api.Domain.Dtos.Endereco
{
  public class EnderecoDto
  {
    public string Cep { get; set; }
    public string Logradouro { get; set; }
    public string Numero { get; set; }
    public MunicipioDtoCompleto Municipio { get; set; }
  }
}
