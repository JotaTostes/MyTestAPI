using Hangfire;
using MyTest.Jobs;

namespace MyTest.WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IRecurringJobManager _recurringJobManager;

        public Worker(ILogger<Worker> logger, IRecurringJobManager recurringJobManager)
        {
            _logger = logger;
            _recurringJobManager = recurringJobManager;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _recurringJobManager.AddOrUpdate<BreedUpsertJob>(
                "BreedUpsertJob",
                job => job.ExecuteAsync(),
                Cron.Minutely);

            await Task.CompletedTask;
        }
    }
}
