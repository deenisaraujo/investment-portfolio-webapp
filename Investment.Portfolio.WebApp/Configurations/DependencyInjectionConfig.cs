using Investment.Portfolio.Core.Factory;
using Investment.Portfolio.Core.Factory.Interface;

namespace Investment.Portfolio.WebApp.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            var connection = configuration.GetConnectionString("INVEST_PORTF");

            var configs = new Dictionary<DataBaseConnection, string>()
            {
                { DataBaseConnection.INVEST_PORTF, connection }
            };

            services.AddSingleton<IConnectionFactory>(s => new ConnectionFactory(configs));
            services.ConfigCommand();
            services.ConfigFacade();
            services.ConfigRepository();
            services.ConfigService();

            return services;
        }
    }
}
