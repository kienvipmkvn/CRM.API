namespace CRM.API.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _secretKey;

        public AuthenticationMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _secretKey = configuration["Authentication:SecretKey"];
        }

        public async Task InvokeAsync(HttpContext context)
        {
            //if (!context.Request.Headers.TryGetValue("x-secret", out var authorizationHeader))
            //{
            //    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            //    await context.Response.WriteAsync("Missing Authorization Header");
            //    return;
            //}

            //var secretKey = authorizationHeader.FirstOrDefault();
            //if (string.IsNullOrWhiteSpace(secretKey) || !secretKey.Equals(_secretKey, StringComparison.OrdinalIgnoreCase))
            //{
            //    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            //    await context.Response.WriteAsync("Invalid Secret Key");
            //    return;
            //}

            // Call the next middleware in the pipeline
            await _next(context);
        }
    }
}
