using JMVPageLogic.Core.Application.Dtos.Estatus;
using JMVPageLogic.Core.Domain.Entities;

namespace JMVPageLogic.Core.Application.Interfaces.Services.Domain_Services
{
    public interface IEstatusService : IGenericService<SaveEstatusDto, EstatusDto, Estatus>
    {
    }
}
