
using ASP;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute (
    name: "default",
    pattern: "{controller=Gettimesuniversal}/{action=GetUtcTimes}"
);

app.Run();