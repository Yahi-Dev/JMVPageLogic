using JMVPageLogic.Core.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace JMVPageLogic.Core.Domain.Entities
{
    public class Tipo : IAuditableEntity
    {
        public string? Nombre { get; set; }
    }
}
