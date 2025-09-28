using JMVPageLogic.Core.Application.Interfaces.Repositories;
using JMVPageLogic.Core.Domain.Entities;
using JMVPageLogic.Infrastructure.Identity.Contexts;
using Microsoft.EntityFrameworkCore;

namespace JMVPageLogic.Infrastructure.Persistence.Repositories
{
    public class PublicacionesRepository : GenericRepository<Publicacion>, IPublicacionesRepository
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<Publicacion> _entities;
        public PublicacionesRepository(ApplicationContext context) : base(context)
        {
            _context = context;
            _entities = _context.Set<Publicacion>();
        }
    }
}
