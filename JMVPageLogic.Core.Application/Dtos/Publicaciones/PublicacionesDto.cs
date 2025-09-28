using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMVPageLogic.Core.Application.Dtos.Publicaciones
{
    public class PublicacionesDto
    {
        public int Id { get; set; }
        public string? IMG { get; set; }
        public string? Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public int Id_Centro { get; set; }
        public int Id_estado { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
