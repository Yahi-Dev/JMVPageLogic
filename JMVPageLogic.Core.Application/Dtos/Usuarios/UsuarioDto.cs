namespace JMVPageLogic.Core.Application.Dtos.Usuarios
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Telefono { get; set; }
        public int IdComunidad { get; set; }
        public int IdCentro { get; set; }
        public int IdVocalia { get; set; }
        public int IdEstatus { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
