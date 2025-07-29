using JMVPageLogic.Core.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace JMVPageLogic.Core.Domain.Entities
{
    public class Vocal : IAuditableEntity
    {
        public string? Name { get; set; }
        public string? Img { get; set; }
        public int IdCentro { get; set; }
        public int IdVocalia { get; set; }

        [ForeignKey("IdCentro")]
        public Centro? Centro { get; set; }

        [ForeignKey("IdVocalia")]
        public Vocalia? Vocalia { get; set; }

        public ICollection<VocalValor>? VocalValores { get; set; }
    }
}
