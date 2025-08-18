using JMVPageLogic.Core.Application.Interfaces.Services;
using JMVPageLogic.Core.Domain.Settings;
using JMVPageLogic.Infrastructure.Shared.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JMVPageLogic.Infrastructure.Shared.IOC
{
    public static class ServiceRegistration
    {
        public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MailSettings>(configuration.GetSection("MailSettings"));
            services.AddTransient<IEmailService, EmailService>();
        }
    }
}
