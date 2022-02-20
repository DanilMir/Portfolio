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
            $@"Request:
        Time: {DateTime.Now}
        Client IP address: {context.Connection.RemoteIpAddress}
        {context.Request.Protocol} {context.Request.Method}
        PATH: {context.Request.Scheme}://{context.Request.Host}{context.Request.Path}
        Params: {queryStr}");
        await _next.Invoke(context);
    }
}