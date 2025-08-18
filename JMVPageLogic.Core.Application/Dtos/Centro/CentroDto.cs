namespace JMVPageLogic.Core.Application.Dtos.Centro
{
    public class CentroDto
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
