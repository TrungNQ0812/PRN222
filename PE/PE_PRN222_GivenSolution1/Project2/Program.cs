using Project2.DAL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddRazorPages();
builder.Services.AddSqlServer<LibraryManagementContext>(builder.Configuration.GetConnectionString("LibraryManagement"));
builder.Services.AddScoped<LibraryManagementContext>();
var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.MapGet("/", context =>
{
    context.Response.Redirect("/Author");
    return Task.CompletedTask;
});
app.MapRazorPages();

app.Run();
