using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


namespace WorkerTemplate.ConsoleApp
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly WorkerParams _workerParams;

        public Worker(ILogger<Worker> logger,
            WorkerParams workerParams)
        {
            logger.LogInformation(
                $"Starting worker...");

            _logger = logger;
            _workerParams = workerParams;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var workers = new List<Task>();
                for (int i = 0; i < _workerParams.WorkersNumber; i++)
                {
                    workers.Add(RunAsync(i, stoppingToken));
                }

                await Task.WhenAll(workers.ToArray());
            }

        }

        private async Task RunAsync(int number, CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation($"Worker {number} running at: {DateTimeOffset.Now:yyyy-MM-dd HH:mm:ss}");
                await Task.Delay(_workerParams.WorkerIntervalActive, stoppingToken);
            }
        }
    }
}

