using dotNetCrudApi.DatabaseContext;
using dotNetCrudApi.Repositories;
using dotNetCrudApi.Services;
using Microsoft.EntityFrameworkCore;

namespace dotNetCrudApi.StartupConfig;

public static class ServicesCollectionConfig
{
    public static IServiceCollection RegisterServices(this IServiceCollection services
        , ConfigurationManager configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<IBlogService, BlogService>();
        services.AddDbContext<BlogDbContext>(options =>
        {
            var connStr = configuration.GetConnectionString("blogDbConString");
            options.UseSqlServer(connStr);
        });
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",
                builder => builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        });

        return services;
    }
}
