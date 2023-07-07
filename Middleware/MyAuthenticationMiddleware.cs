namespace ASP
{
    public class MyAuthenticationMiddleware
    {
        private RequestDelegate _next;
        private string _login;
        private string _password;
        public MyAuthenticationMiddleware(RequestDelegate next, string login, string password)
        {
            _next = next;
            _login = login;
            _password = password;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var login = context.Request.Query["login"].ToString();
            var password = context.Request.Query["passwd"].ToString();
            string reversedLogin = new string(login.Reverse().ToArray());
            string reversedPass = new string(password.Reverse().ToArray());

            if ((string.IsNullOrWhiteSpace(login) || reversedLogin != _login) 
                || (string.IsNullOrWhiteSpace(password) || reversedPass != _password))
            {
                context.Response.StatusCode = 403;
            }
            else await _next.Invoke(context);
        }
    }
}
