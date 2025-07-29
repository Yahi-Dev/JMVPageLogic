using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using JMVPageLogic.Core.Domain.Common;

namespace JMVPageLogic.Core.Domain.Entities
{
    public class Valor : IAuditableEntity
    {
        [Required]
        [MaxLength(100)]
        public string? Nombre { get; set; }

        public ICollection<VocalValor>? VocalValores { get; set; }
    }

}
