using Api.Domain.Dtos.Uf;

namespace Api.Domain.Dtos.Municipio
{
    public class MunicipioDtoCompleto
    {
        public ushort Id { get; set; }
        public string Nome { get; set; }
        public UfDto Uf { get; set; }
    }
}
