using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using JMVPageLogic.Core.Domain.Common;

namespace JMVPageLogic.Core.Domain.Entities
{
    public class Publicacion : IAuditableEntity
    {
        public string? IMG { get; set; }
        public string? Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public int Id_Centro { get; set; }
        public int Id_estado { get; set; }

        [ForeignKey("Id_Centro")]
        public Centro? Centro { get; set; }

        public ICollection<Actividades>? Actividades { get; set; }
    }
}
