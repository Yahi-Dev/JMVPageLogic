using JMVPageLogic.Core.Application.Interfaces.Services;
using JMVPageLogic.Infrastructure.Identity.Contexts;
using JMVPageLogic.Infrastructure.Identity.Entities;
using JMVPageLogic.Infrastructure.Identity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JMVPageLogic.Infrastructure.Identity.IOC
{
    public static class ServiceRegistration
    {
        public static void IdentityLayerRegistration(this IServiceCollection service, IConfiguration configuration)
        {
            #region Context
            if (configuration.GetValue<bool>("UserInMemoryDatabase"))
            {
                service.AddDbContext<IdentityContext>(options => options.UseInMemoryDatabase("InMemoryIdentity"));
            }
            else
            {
                service.AddDbContext<IdentityContext>(options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("IdentityConnection"),
                    m => m.MigrationsAssembly(typeof(IdentityContext).Assembly.FullName));
                });
            }
            #endregion

            #region Services


            service.AddIdentity<AppUser, IdentityRole>()
              .AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders();

            service.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/User";
                options.AccessDeniedPath = "/User/AccessDenied";
            });

            service.AddAuthentication();

            #endregion

            service.AddTransient<IAccountService, AccountService>();
        }
    }
}
