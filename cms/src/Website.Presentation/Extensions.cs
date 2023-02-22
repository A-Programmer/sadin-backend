using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Website.Common.WebFrameworks.FilterAttributes;

namespace Website.Presentation;

public static class Extensions
{
    public static IServiceCollection AddPresentationLayer(this IServiceCollection services)
    {
        services.AddControllers(options =>
            {
                options.Filters.Add<ApiExceptionFilterAttribute>();
            })
            .AddApplicationPart(typeof(Presentation.Extensions).Assembly);
        return services;
    }

    public static IApplicationBuilder UsePresentationLayer(this IApplicationBuilder app)
    {
        return app;
    }
}