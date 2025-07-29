using JMVPageLogic.Core.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace JMVPageLogic.Core.Domain.Entities
{
    public class Biblioteca : IAuditableEntity
    {
        public string? Ruta_doc { get; set; }
        public string? Titulo { get; set; }
    }
}
