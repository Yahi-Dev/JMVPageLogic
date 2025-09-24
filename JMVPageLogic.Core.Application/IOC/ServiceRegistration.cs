using JMVPageLogic.Core.Application.Interfaces.Services.Domain_Services;
using JMVPageLogic.Core.Application.Services.Domain_Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace JMVPageLogic.Core.Application.IOC
{
    public static class ServiceRegistration
    {
        public static void ApplicationLayerRegistration(this IServiceCollection services)
        {
            // Fix: Use AddAutoMapper(params Assembly[]) overload
            services.AddAutoMapper(cfg => cfg.AddMaps(Assembly.GetExecutingAssembly()));
            services.AddTransient(typeof(IGenericService<,,>), typeof(GenericService<,,>));
            services.AddTransient<IUsuariosService, UsuariosService>();
            services.AddTransient<IActividadesService, ActividadesService>();
            services.AddTransient<IBibliotecaService, BibliotecaService>();
            services.AddTransient<IPublicacionesService, PublicacionesService>();

            services.AddTransient<ICentroService, CentroService>();
            services.AddTransient<IComunidadService, ComunidadService>();
            services.AddTransient<IEstatusService, EstatusService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
