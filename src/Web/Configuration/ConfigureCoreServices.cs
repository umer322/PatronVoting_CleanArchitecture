using Core.Interfaces;
using Infrastructure.Data;

namespace Web.Configuration
{
    public static class ConfigureCoreServices
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));

            return services;
        }
    }
}
