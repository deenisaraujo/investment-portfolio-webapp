using Investment.Portfolio.Core.Service;
using Investment.Portfolio.Core.Service.Interface;

namespace Investment.Portfolio.WebApp.Configurations
{
    public static class ServiceConfig
    {
        public static void ConfigService(this IServiceCollection services)
        {
            //Email
            services.AddScoped<IEnviarEmailService, EnviarEmailService>();
            
        }
    }
}
