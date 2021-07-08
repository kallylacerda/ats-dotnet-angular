using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class MunicipioEntity
    {
        [Key]
        public ushort Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        public byte UfId { get; set; }

        public UfEntity Uf { get; set; }

        public IEnumerable<EnderecoEntity> Enderecos { get; set; }
    }
}
