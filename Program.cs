
using ASP;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IGetBrowser, GetChrome>();
builder.Services.AddSingleton<IGetBrowser, GetFirefox>();
builder.Services.AddSingleton<IGetBrowser, GetOpera>();
builder.Services.AddSingleton<IGetBrowser, GetOther>();

var app = builder.Build();

app.UseMiddleware<GetBrowserMiddleware>();
app.Run();