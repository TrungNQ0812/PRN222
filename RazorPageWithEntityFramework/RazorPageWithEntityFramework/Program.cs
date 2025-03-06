using Microsoft.EntityFrameworkCore;
using RazorPageWithEntityFramework.DAL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FuNewsManagementContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("FuNewsManagement")));

builder.Services.AddScoped<FuNewsManagementContext>();
// Add services to the container.
builder.Services.AddRazorPages();

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
