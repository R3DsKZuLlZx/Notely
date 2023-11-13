using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Quartz;

namespace Notely.Infrastructure.Jobs;

[DisallowConcurrentExecution]
public abstract class BaseJob<T>(ILogger logger, IMediator mediator) : IJob, IConfigureOptions<QuartzOptions>
    where T : BaseJob<T>
{
    public async Task Execute(IJobExecutionContext context)
    {
        using var scopeCronJob = logger.BeginScope("CronJob");

        var jobName = GetType().FullName ?? "Unknown Job";
        using var scopeJobName = logger.BeginScope(jobName);

        var jobId = Guid.NewGuid().ToString();
        using var scopeJobId = logger.BeginScope(jobId);
        try
        {
            logger.LogInformation("Starting Job {JobId}", jobId);
            var command = GetCommand();

            var response = await mediator.Send(command, context.CancellationToken);

            logger.LogInformation("Completed {JobId}: {@Response}", jobId, response);
        }
        catch (Exception e)
        {
            logger.LogError(e, "Failed Job {JobId}", jobId);
        }
    }

    public void Configure(QuartzOptions options)
    {
        var jobName = typeof(T).FullName ?? "Unknown Job";
        var jobKey = JobKey.Create(jobName);
        
        var cronSchedule = GetCronSchedule();
        if (string.IsNullOrWhiteSpace(cronSchedule))
        {
            // schedule it for the distant future so it never runs
            cronSchedule = $"0 0 23 1 1 ? {DateTime.UtcNow.Year + 100}";
        }
        
        options
            .AddJob<T>(jobBuilder => jobBuilder.WithIdentity(jobKey))
            .AddTrigger(trigger => trigger
                .ForJob(jobKey)
                .WithIdentity($"{jobName}-trigger")
                .WithCronSchedule(cronSchedule));
    }

    protected abstract IBaseRequest GetCommand();

    protected abstract string GetCronSchedule();
}
