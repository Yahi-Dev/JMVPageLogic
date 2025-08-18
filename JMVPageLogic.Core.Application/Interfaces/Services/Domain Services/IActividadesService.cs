
using JMVPageLogic.Core.Application.Dtos.Actividades;
using JMVPageLogic.Core.Domain.Entities;

namespace JMVPageLogic.Core.Application.Interfaces.Services.Domain_Services
{
    public interface IActividadesService : IGenericService<SaveActividadesDto, ActividadesDto, Actividades>
    {
    }
}
