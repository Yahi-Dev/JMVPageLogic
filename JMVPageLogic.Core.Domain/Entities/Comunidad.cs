using JMVPageLogic.Core.Domain.Common;
using JMVPageLogic.Core.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

public class Comunidad : IAuditableEntity
{
    public string? Nombre { get; set; }
    public int Integrantes { get; set; }
    public int IdEtapa { get; set; }

    public int CentroId { get; set; }  

    public int EstatusId { get; set; }  

    [ForeignKey("CentroId")]
    public Centro? Centro { get; set; }

    [ForeignKey("EstatusId")]
    public Estatus? Estatus { get; set; }
}