using Blackbird.Application.Infrastructure.Persistence;
using Blackbird.Persistence;
using Blackbird.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Blackbird.Application.Integration.Tests;

public class TestFixture : IDisposable
{
    public IServiceProvider ServiceProvider { get; }

    public TestFixture()
    {
        var services = new ServiceCollection();
        services.AddDbContext<BlackbirdDbContext>(options => options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=BlackbirdIntegrationTestsConnectionStringtDb111;Trusted_Connection=True;"));
        // Register your application services here
        services.AddScoped<IProductRepository, ProductRepository>();

        ServiceProvider = services.BuildServiceProvider();

        using var scope = ServiceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<BlackbirdDbContext>();
        dbContext.Database.EnsureDeleted();
        dbContext.Database.EnsureCreated();
    }

    public void Dispose()
    {
        using var scope = ServiceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<BlackbirdDbContext>();
        dbContext.Database.CloseConnection();
    }
}
