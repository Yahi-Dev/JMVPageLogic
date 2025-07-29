using JMVPageLogic.Core.Application.Interfaces.Repositories;
using JMVPageLogic.Infrastructure.Identity.Contexts;
using JMVPageLogic.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JMVPageLogic.Infrastructure.Identity.IOC
{
    public static class ServiceRegistration
    {
        public static void PersistenceLayerRegistration(this IServiceCollection service, IConfiguration configuration)
        {
            #region Context
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                service.AddDbContext<ApplicationContext>(options =>
                                                        options.UseInMemoryDatabase("JMV"));
            }
            else
            {
                service.AddDbContext<ApplicationContext>((sp, options) =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName));
                });

            }
            #endregion

            #region Repositories 
            service.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            service.AddTransient<IActividadesRepository, ActividadesRepository>();
            service.AddTransient<IBibliotecaRepository, BibliotecaRepository>();
            service.AddTransient<ICentroRepository, CentroRepository>();
            service.AddTransient<IComunidadRepository, ComunidadRepository>();
            service.AddTransient<IEstatusRepository, EstatusRepository>();
            #endregion
        }
    }
}
