using System.ComponentModel.DataAnnotations.Schema;


namespace JMVPageLogic.Core.Domain.Entities
{
    public class VocalValor
    {
        public int Id { get; set; }
        public int VocalId { get; set; }
        public int ValorId { get; set; }

        [ForeignKey("VocalId")]
        public Vocal? Vocal { get; set; }

        [ForeignKey("ValorId")]
        public Valor? Valor { get; set; }
    }
}
