var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();

builder.Services.AddRazorPages()
	.AddRazorPagesOptions(options =>
	{
		options.Conventions.AddPageRoute("/MyData", "");
	});

var app = builder.Build();
app.MapRazorPages();

app.Run();