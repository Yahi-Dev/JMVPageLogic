using JMVPageLogic.Core.Application.Interfaces.Repositories;
using JMVPageLogic.Core.Domain.Entities;
using JMVPageLogic.Infrastructure.Identity.Contexts;
using Microsoft.EntityFrameworkCore;

namespace JMVPageLogic.Infrastructure.Persistence.Repositories
{
    public class EstatusRepository : GenericRepository<Estatus>, IEstatusRepository
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<Estatus> _entities;
        public EstatusRepository(ApplicationContext context) : base(context)
        {
            _context = context;
            _entities = _context.Set<Estatus>();
        }
    }
}
