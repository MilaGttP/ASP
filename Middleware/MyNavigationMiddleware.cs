
namespace ASP
{
    public class MyNavigationMiddleware
    {
        private RequestDelegate _next;
        public MyNavigationMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.ContentType = "text/html; charset=utf-8";
            string path = context.Request.Path.Value != null ? context.Request.Path.Value.ToLower() : "";

            switch (path)
            {
                case "/home":
                    await context.Response.WriteAsync("<h1>Домашня сторінка</h1>");
                    break;

                case "/mypicture":
                    context.Response.ContentType = "image/png";
                    await context.Response.SendFileAsync("Assets\\unnamed.png");
                    break;

                case "/mycredential":
                    await context.Response.WriteAsJsonAsync($"Login: {context.Request.Query["login"]}, " +
                        $"Password: {context.Request.Query["passwd"]}");
                    break;

                default:
                    context.Response.StatusCode = 404;
                    break;
            }
        }
    }
}
