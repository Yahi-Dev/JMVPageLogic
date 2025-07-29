using JMVPageLogic.Core.Application.Interfaces.Repositories;
using JMVPageLogic.Core.Domain.Entities;
using JMVPageLogic.Infrastructure.Identity.Contexts;
using Microsoft.EntityFrameworkCore;

namespace JMVPageLogic.Infrastructure.Persistence.Repositories
{
    public class ComunidadRepository : GenericRepository<Comunidad>, IComunidadRepository
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<Comunidad> _entities;
        public ComunidadRepository(ApplicationContext context) : base(context)
        {
            _context = context;
            _entities = _context.Set<Comunidad>();
        }
    }
}
