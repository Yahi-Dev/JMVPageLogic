using AutoMapper;
using JMVPageLogic.Core.Application.Dtos.Actividades;
using JMVPageLogic.Core.Application.Dtos.Publicaciones;
using JMVPageLogic.Core.Application.Interfaces.Repositories;
using JMVPageLogic.Core.Application.Interfaces.Services;
using JMVPageLogic.Core.Application.Interfaces.Services.Domain_Services;
using JMVPageLogic.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace JMVPageLogic.Core.Application.Services.Domain_Services
{
    public class PublicacionesService : GenericService<SavePublicacionesDto, PublicacionesDto, Publicacion>, IPublicacionesService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly IPublicacionesRepository _repository;
        private readonly IAccountService _accountService;
        public PublicacionesService(
            IMapper mapper,
            IPublicacionesRepository repository,
            IAccountService accountService) : base(repository, mapper)
        {
            _mapper = mapper;
            _repository = repository;
            _accountService = accountService;
        }
    }
}
