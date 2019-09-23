public class LoggerMiddle
{
    private readonly RequestDelegate _next;
    public LoggerMiddle(RequestDelegate next) => this._next = next;

    private Logger log = LogManager.GetLogger("logger");

    public async Task InvokeAsync(HttpContext context)
    {
        log.Info($"请求路径：{context.Request.Path + context.Request.QueryString.Value}");

        if (!context.Request.Method.Equals("GET"))
        {
            using (var data = new MemoryStream())
            {
                await context.Request.Body.CopyToAsync(data);
                log.Info($"请求 body：{Encoding.Default.GetString(data.ToArray())}");
            }
        }
        await _next(context);
    }
}