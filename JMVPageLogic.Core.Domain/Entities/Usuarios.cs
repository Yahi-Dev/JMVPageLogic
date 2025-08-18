using JMVPageLogic.Core.Domain.Common;

namespace JMVPageLogic.Core.Domain.Entities
{
    public class Usuarios : IAuditableEntity
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Telefono { get; set; }

        public int IdComunidad { get; set; }
        public int IdCentro { get; set; }
        public int IdVocalia { get; set; }
        public int IdEstatus { get; set; }


        //Navigation Properties
        public Comunidad? Comunidad { get; set; }
        public Centro? Centro { get; set; }
        public Vocalia? Vocalia { get; set; }
        public Estatus? Estatus { get; set; }
    }
}
