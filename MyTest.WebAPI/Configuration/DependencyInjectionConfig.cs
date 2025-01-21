using MyTest.Application.Interfaces;
using MyTest.Application.Services;
using MyTest.Infrastructure.Data;
using MyTest.Infrastructure.HttpClients;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MyTest.Domain.Interfaces;
using MyTest.Infrastructure.Repositories;

namespace MyTest.WebAPI.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DogDbContext>(options =>
                options.UseMySQL(configuration.GetConnectionString("MySqlConnection"))
                .EnableSensitiveDataLogging()
                .LogTo(Console.WriteLine));

            services.AddScoped<IBreedService, BreedService>();
            services.AddScoped<IBreedRepository, BreedRepository>();
            services.AddHttpClient<DogApiClient>(client =>
            {
                client.BaseAddress = new Uri("https://dogapi.dog/api/v2");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            return services;
        }
    }
}
