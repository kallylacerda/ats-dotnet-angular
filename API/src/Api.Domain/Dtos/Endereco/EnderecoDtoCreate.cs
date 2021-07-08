using System.ComponentModel.DataAnnotations;
using Api.Domain.Validations;

namespace Api.Domain.Dtos.Endereco
{
  public class EnderecoDtoCreate
  {
    [Required(ErrorMessage = "CEP é obrigatório")]
    public string Cep { get; set; }

    [Required(ErrorMessage = "Logradouro é obrigatório")]
    [StringLength(60, ErrorMessage = "Logradouro deve ter no máximo {1} caracteres")]
    public string Logradouro { get; set; }

    public string Numero { get; set; }

    [Required(ErrorMessage = "Município é obrigatório")]
    [GreaterThan0(ErrorMessage = "Id não pode ser 0")]
    public ushort MunicipioId { get; set; }
  }
}
