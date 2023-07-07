
using ASP;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

string login = "user";
string password = "12345";

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseErrorHandling();
app.UseCustomAuthentication(login, password);
app.UseCustomNavigation();

app.Run();