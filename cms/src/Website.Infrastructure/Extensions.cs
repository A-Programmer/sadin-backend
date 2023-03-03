using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Website.Domain;
using Website.Domain.Aggregates.Categories;
using Website.Domain.Contracts;
using Website.Infrastructure.Data;
using Website.Infrastructure.Interceptors;
using Website.Infrastructure.Repositories;

namespace Website.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructureLayerServices(this IServiceCollection services, IConfiguration configurations)
    {
        services.AddSingleton<ConvertDomainEventsToOutboxMessageInterceptor>();
        services.AddDbContext<WebsiteDbContext>((sp, options) =>
        {
            var interceptor = sp.GetService<ConvertDomainEventsToOutboxMessageInterceptor>();
            options.UseSqlServer(
                configurations.GetConnectionString("SqlServerConnection"))
                .AddInterceptors(interceptor);
        });
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }

    public static IApplicationBuilder UseInfrastructureLayer(this IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            var context = serviceScope.ServiceProvider.GetRequiredService<WebsiteDbContext>();
            context.Database.Migrate();
        }
        using(var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            var context = serviceScope.ServiceProvider.GetRequiredService<WebsiteDbContext>();
            DataSeeder.Seed(context);
        }
        return app;
    }
}
