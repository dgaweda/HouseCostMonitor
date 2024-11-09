namespace HouseCostMonitor.API.Middlewares;

using System.Diagnostics;

public class TimeLoggingMiddleware(ILogger<TimeLoggingMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var timestamp = Stopwatch.GetTimestamp();
        await next.Invoke(context);
        var elapsedTime = Stopwatch.GetElapsedTime(timestamp);
        
        if(elapsedTime.Seconds >= 4)
            logger.LogWarning("Request [HTTP {Verb}] at [{Path}] took {Time} ms", 
                context.Request.Method, 
                context.Request.Path, 
                elapsedTime.Milliseconds);
    }
}