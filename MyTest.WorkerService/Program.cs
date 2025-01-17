using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyTest.Application.Interfaces;
using MyTest.Application.Services;
using MyTest.Jobs;
using MyTest.WorkerService;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddHangfire(config => config.UseMemoryStorage());
                services.AddHangfireServer();

                services.AddSingleton<IRecurringJobManager, RecurringJobManager>();
                services.AddScoped<IBreedService, BreedService>();
                services.AddScoped<BreedUpsertJob>();

                services.AddHostedService<Worker>();
            });
}
