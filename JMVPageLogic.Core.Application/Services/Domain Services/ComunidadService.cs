using AutoMapper;
using JMVPageLogic.Core.Application.Dtos.Comunidad;
using JMVPageLogic.Core.Application.Interfaces.Repositories;
using JMVPageLogic.Core.Application.Interfaces.Services;
using JMVPageLogic.Core.Application.Interfaces.Services.Domain_Services;
using Microsoft.AspNetCore.Http;

namespace JMVPageLogic.Core.Application.Services.Domain_Services
{
    public class ComunidadService : GenericService<SaveComunidadDto, ComunidadDto, Comunidad>, IComunidadService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly IComunidadRepository _repository;
        private readonly IAccountService _accountService;
        public ComunidadService(
            IMapper mapper,
            IComunidadRepository repository,
            IAccountService accountService) : base(repository, mapper)
        {
            _mapper = mapper;
            _repository = repository;
            _accountService = accountService;
        }
    }
}
