using AutoMapper;
using JMVPageLogic.Core.Application.Dtos.Centro;
using JMVPageLogic.Core.Application.Interfaces.Repositories;
using JMVPageLogic.Core.Application.Interfaces.Services;
using JMVPageLogic.Core.Application.Interfaces.Services.Domain_Services;
using Microsoft.AspNetCore.Http;

namespace JMVPageLogic.Core.Application.Services.Domain_Services
{
    public class CentroService : GenericService<SaveCentroDto, CentroDto, Centro>, ICentroService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly ICentroRepository _repository;
        private readonly IAccountService _accountService;
        public CentroService(
            IMapper mapper,
            ICentroRepository repository,
            IAccountService accountService) : base(repository, mapper)
        {
            _mapper = mapper;
            _repository = repository;
            _accountService = accountService;
        }
    }
}
