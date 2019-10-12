public class LoggerMiddle
{
    private readonly RequestDelegate _next;
        public LoggerMiddle(RequestDelegate next) => this._next = next;

        private Logger log = LogManager.GetLogger("logger");

        public async Task InvokeAsync(HttpContext context)
        {
            Thread.CurrentThread.Name = CommFunc.GenerateShortGuid();

            log.Info($"请求路径：{context.Request.Path + context.Request.QueryString.Value}");

            if (!context.Request.Method.Equals("GET"))
            {
                context.Request.EnableBuffering();
                using (var data = new StreamReader(context.Request.Body, Encoding.UTF8, false, 1024, true))
                {
                    var body = await data.ReadToEndAsync();
                    log.Info($"请求 body：{body.Replace("\n","").Trim()}");
                    context.Request.Body.Seek(0, SeekOrigin.Begin);
                }
            }
            await _next(context);
        }
}
