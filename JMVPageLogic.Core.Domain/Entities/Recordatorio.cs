using JMVPageLogic.Core.Domain.Common;

namespace JMVPageLogic.Core.Domain.Entities
{
    public class Recordatorio : IAuditableEntity
    {
        public DateTime Fecha { get; set; }
        public int IdPublicacion { get; set; }

        public bool IsPublicacion { get; set; } = false;

        public Publicacion? Publicacion { get; set; } 
    }
}
