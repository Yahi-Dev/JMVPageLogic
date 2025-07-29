using JMVPageLogic.Core.Application.Interfaces.Repositories;
using JMVPageLogic.Core.Domain.Entities;
using JMVPageLogic.Infrastructure.Identity.Contexts;
using Microsoft.EntityFrameworkCore;

namespace JMVPageLogic.Infrastructure.Persistence.Repositories
{
    public class ActividadesRepository : GenericRepository<Actividades>, IActividadesRepository
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<Actividades> _entities;
        public ActividadesRepository(ApplicationContext context) : base(context)
        {
            _context = context;
            _entities = _context.Set<Actividades>();
        }
    }
}
