using JMVPageLogic.Core.Application.Interfaces.Repositories;
using JMVPageLogic.Core.Domain.Entities;
using JMVPageLogic.Infrastructure.Identity.Contexts;
using Microsoft.EntityFrameworkCore;

namespace JMVPageLogic.Infrastructure.Persistence.Repositories
{
    public class BibliotecaRepository : GenericRepository<Biblioteca>, IBibliotecaRepository
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<Biblioteca> _entities;
        public BibliotecaRepository(ApplicationContext context) : base(context)
        {
            _context = context;
            _entities = _context.Set<Biblioteca>();
        }
    }
}
