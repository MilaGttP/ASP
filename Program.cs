using Microsoft.EntityFrameworkCore;
using ASP.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddXmlDataContractSerializerFormatters();

builder.Services.AddDbContext<ItemsContext>(options =>
				options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapControllers();

app.Run();
