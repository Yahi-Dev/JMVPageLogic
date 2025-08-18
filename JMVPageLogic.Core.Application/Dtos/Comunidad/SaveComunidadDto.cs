namespace JMVPageLogic.Core.Application.Dtos.Comunidad
{
    public class SaveComunidadDto
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int Integrantes { get; set; }
        public int IdEtapa { get; set; }

        public int CentroId { get; set; }

        public int EstatusId { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
