namespace LibraryApp.Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception occurred.");
                httpContext.Response.StatusCode = 500;
                httpContext.Response.ContentType = "application/json";

                await httpContext.Response.WriteAsJsonAsync(new
                {
                    StatusCode = 500,
                    Message = "Internal server error"
                });
            }
        }
    }
}