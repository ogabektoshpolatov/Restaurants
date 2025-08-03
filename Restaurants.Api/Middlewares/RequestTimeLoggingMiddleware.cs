using System.Diagnostics;

namespace Restaurants.Api.Middlewares;

public class RequestTimeLoggingMiddleware(ILogger<RequestTimeLoggingMiddleware> logger):IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        Stopwatch stopwatch = new Stopwatch();
        
        stopwatch.Start();
        await next.Invoke(context);
        stopwatch.Stop();

        if (stopwatch.ElapsedMilliseconds / 100 > 4)
        {
            logger.LogInformation($"Request {context.Request.Method} at {context.Request.Path} took {stopwatch.ElapsedMilliseconds} milliseconds");
        }
    }
}