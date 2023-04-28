using Blackbird.Application;
using Blackbird.Application.Features.Products.Queries;
using Blackbird.Infrastructure;
using Blackbird.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/products", async (IMediator mediator) =>
{
    var products = await mediator.Send(new GetAllProductsQuery());
    return Results.Ok(products);
})
.WithName("GetProducts")
.WithOpenApi();

using var scope = app.Services.CreateScope();
try
{
    var context = scope.ServiceProvider.GetService<BlackbirdDbContext>();
    if (context != null)
    {
        await context.Database.EnsureDeletedAsync();
        await context.Database.MigrateAsync();
    }
}
catch (Exception ex)
{
    var logger = scope.ServiceProvider.GetRequiredService<ILogger>();
    logger.LogError(ex, "An error occurred while migrating the database.");
}

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
