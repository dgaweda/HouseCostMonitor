namespace HouseCostMonitor.API.Middlewares;

public class TimeLoggingMiddleware(ILogger<TimeLoggingMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        await next.Invoke(context);
    }

    private void LogHttpRequestRunningLongerThan4Secs(HttpContext context)
    {
        logger.LogWarning($"{context.Request}");
    }
}