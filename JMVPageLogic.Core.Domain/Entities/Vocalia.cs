using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using JMVPageLogic.Core.Domain.Common;

namespace JMVPageLogic.Core.Domain.Entities
{
    public class Vocalia : IAuditableEntity
    {
        public string? Nombre { get; set; }
        public int Id_Tipovocalia { get; set; }

        [ForeignKey("Id_Tipovocalia")]
        public Tipo? Tipo { get; set; } //Nacional o de Centro

        public ICollection<Usuarios>? Usuarios { get; set; }
    }
}
