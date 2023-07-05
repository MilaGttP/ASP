
var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

var app = builder.Build();

app.Run(async (context) =>
{
    var request = context.Request;
    var path = context.Request.Path;
    context.Response.ContentType = "text/html; charset=utf-8";

    switch (path)
    {
        case "/info":
            await context.Response.WriteAsync($"Host: {request.Host}, Path: {request.Path}, QueryString: {request.QueryString}");
            break;
        case "/time":
            await context.Response.WriteAsync($"DateTime: {DateTime.Now}");
            break;
        case "/key":
            string value = app.Configuration["key"];
            await context.Response.WriteAsync($"Value: {value}");
            break;
        default:
            await context.Response.WriteAsync("Привіт користувачеві NET 6.0");
            break;
    }
}); 

app.Run();