using JMVPageLogic.Core.Application.Interfaces.Repositories;
using JMVPageLogic.Core.Domain.Entities;
using JMVPageLogic.Infrastructure.Identity.Contexts;
using Microsoft.EntityFrameworkCore;

namespace JMVPageLogic.Infrastructure.Persistence.Repositories
{
    public class UsuariosRepository : GenericRepository<Usuarios>, IUsuariosRepository
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<Usuarios> _entities;
        public UsuariosRepository(ApplicationContext context) : base(context)
        {
            _context = context;
            _entities = _context.Set<Usuarios>();
        }
    }
}
