using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using JMVPageLogic.Core.Domain.Common;


namespace JMVPageLogic.Core.Domain.Entities
{
    public class Actividades : IAuditableEntity
    {
        public int Id_Publicacion { get; set; }
        public int Id_Centro { get; set; }

        [ForeignKey("Id_Publicacion")]
        public Publicacion? Publicacion { get; set; }

        [ForeignKey("Id_Centro")]
        public Centro? Centro { get; set; }
    }
}
