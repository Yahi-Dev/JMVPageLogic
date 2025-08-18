using JMVPageLogic.Core.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace JMVPageLogic.Core.Domain.Entities
{
    public class Estatus : IAuditableEntity
    {
        public string? Nombre { get; set; }

        public ICollection<Usuarios>? Usuarios { get; set; }
    }
}
