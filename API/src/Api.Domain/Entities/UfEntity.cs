using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class UfEntity
    {
        [Key]
        public byte Id { get; set; }

        [Required]
        [MaxLength(2)]
        public string Sigla { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }

        public IEnumerable<MunicipioEntity> Municipios { get; set; }
    }
}
