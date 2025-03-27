using TrungNQ_Project_PRN222.DAL;
using TrungNQ_Project_PRN222.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSqlServer<InternalDocumentManagementContext>
    (builder.Configuration.GetConnectionString("InternalDocumentManagement")); // Add context when no hard code

builder.Services.AddScoped(typeof(InternalDocumentManagementContext));



builder.Services.AddControllersWithViews();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Index");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
