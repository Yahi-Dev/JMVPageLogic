
using JMVPageLogic.Core.Application.Dtos.Publicaciones;
using JMVPageLogic.Core.Domain.Entities;

namespace JMVPageLogic.Core.Application.Interfaces.Services.Domain_Services
{
    public interface IPublicacionesService : IGenericService<SavePublicacionesDto, PublicacionesDto, Publicacion>
    {
    }
}
