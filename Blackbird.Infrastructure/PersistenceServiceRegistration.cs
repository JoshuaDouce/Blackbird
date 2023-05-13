using Blackbird.Application.Infrastructure.Persistence;
using Blackbird.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blackbird.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BlackbirdDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("BlackbirdConnectionString")));

            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
