using Infrastructure.Data;
using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class Dependencies
    {
        public static void ConfigureDependencies(IConfiguration configuration, IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(o =>
            {
                o.UseSqlServer(configuration.GetConnectionString("DbConnection"));
            });
            services.AddDbContext<AppIdentityDbContext>(o =>
            {
                o.UseSqlServer(configuration.GetConnectionString("IdentityConnection"));
            });
        }
    }
}
