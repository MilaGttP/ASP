using Microsoft.EntityFrameworkCore;
using ASP.Models;
using ASP.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BooksContext>(options =>
				options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddRazorPages();;
builder.Services.AddTransient<IDatabaseHandlerRepository, DatabaseHandler>();
builder.Services.AddTransient<IBooksPageSorterFilter, BooksPageSorterFilter>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
