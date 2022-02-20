namespace Portfolio.Middleware;

public class LoggerMiddleware
{
    private readonly RequestDelegate _next;

    public LoggerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var query = context.Request.Query;
        var queryStr = query.Aggregate("", (current, q) => 
            $"{current}{q.Key}={q.Value}\n");

        Console.WriteLine(
            $"Request:\nTime: {DateTime.Now}\nRemote IP address: {context.Connection.RemoteIpAddress}\n" +
            $"{context.Request.Protocol} {context.Request.Method}\n" +
            $"PATH: {context.Request.Scheme}://{context.Request.Host}{context.Request.Path}\n" +
            $"Params: {queryStr}"
        );
        await _next.Invoke(context);
    }
}