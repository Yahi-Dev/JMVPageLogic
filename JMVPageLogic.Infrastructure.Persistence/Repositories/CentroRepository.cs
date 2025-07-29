using JMVPageLogic.Core.Application.Interfaces.Repositories;
using JMVPageLogic.Core.Domain.Entities;
using JMVPageLogic.Infrastructure.Identity.Contexts;
using Microsoft.EntityFrameworkCore;


namespace JMVPageLogic.Infrastructure.Persistence.Repositories
{
    public class CentroRepository : GenericRepository<Centro>, ICentroRepository
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<Centro> _entities;
        public CentroRepository(ApplicationContext context) : base(context)
        {
            _context = context;
            _entities = _context.Set<Centro>();
        }
    }
}
