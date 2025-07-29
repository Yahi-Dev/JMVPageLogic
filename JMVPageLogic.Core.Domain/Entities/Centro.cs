using JMVPageLogic.Core.Domain.Common;
using JMVPageLogic.Core.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

public class Centro : IAuditableEntity
{
    public string? Nombre { get; set; }
    public string? Direccion { get; set; }



    [ForeignKey("Id")]  
    public Estatus? Estatus { get; set; }

    public ICollection<Publicacion>? Publicaciones { get; set; }
    public ICollection<Actividades>? Actividades { get; set; }
}