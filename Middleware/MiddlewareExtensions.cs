namespace ASP
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MyErrorHandlingMiddleware>();
        }
        public static IApplicationBuilder UseCustomAuthentication(this IApplicationBuilder app, string login, string password)
        {
            return app.UseMiddleware<MyAuthenticationMiddleware>(login, password);
        }
        public static IApplicationBuilder UseCustomNavigation(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MyNavigationMiddleware>();
        }
    }
}
