using JMVPageLogic.Core.Application.Dtos.Usuarios;
using JMVPageLogic.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMVPageLogic.Core.Application.Interfaces.Services.Domain_Services
{
    public interface IUsuariosService : IGenericService<SaveUsuarioDto, UsuarioDto, Usuarios>
    { 

    }
}
