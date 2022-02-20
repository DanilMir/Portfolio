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
        var queryStr = context.Request.Query.Aggregate("", (current, q) => 
            $"{current}{q.Key}={q.Value}\n");

        Console.WriteLine(
            $"Request:\nTime: {DateTime.Now}\nClient IP address: {context.Connection.RemoteIpAddress}\n{context.Request.Protocol} {context.Request.Method}\nPATH: {context.Request.Scheme}://{context.Request.Host}{context.Request.Path}\nParams: {queryStr}"
        );
        await _next.Invoke(context);
    }
}