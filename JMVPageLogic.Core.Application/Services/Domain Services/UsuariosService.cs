using AutoMapper;
using JMVPageLogic.Core.Application.Dtos.Usuarios;
using JMVPageLogic.Core.Application.Interfaces.Repositories;
using JMVPageLogic.Core.Application.Interfaces.Services;
using JMVPageLogic.Core.Application.Interfaces.Services.Domain_Services;
using JMVPageLogic.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace JMVPageLogic.Core.Application.Services.Domain_Services
{
    public class UsuariosService : GenericService<SaveUsuarioDto, UsuarioDto, Usuarios>, IUsuariosService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly IUsuariosRepository _repository;
        private readonly IAccountService _accountService;
        public UsuariosService(
            IMapper mapper,
            IUsuariosRepository repository,
            IAccountService accountService) : base(repository, mapper)
        {
            _mapper = mapper;
            _repository = repository;
            _accountService = accountService;
        }
    }
}
