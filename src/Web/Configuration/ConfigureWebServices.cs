using Web.Services;

namespace Web.Configuration
{
    public static class ConfigureWebServices
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services)
        {
            services.AddScoped<CharactersViewModelService>();
            return services;
        }
    }
}
