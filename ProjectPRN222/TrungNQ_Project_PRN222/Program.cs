using TrungNQ_Project_PRN222.DAL;
using TrungNQ_Project_PRN222.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Thời gian hết hạn session
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
//--------------------------------------------------------------------------------------------------------------------
builder.Services.AddSqlServer<InternalDocumentManagementContext>
    (builder.Configuration.GetConnectionString("InternalDocumentManagement")); // Add context when no hard code

builder.Services.AddScoped(typeof(InternalDocumentManagementContext));
//--------------------------------------------------------------------------------------------------------------------
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<AccountRepository>();
builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();
builder.Services.AddScoped<DocumentRepository>();
builder.Services.AddScoped<IDocumentStatusRepository, DocumentStatusRepository>();
builder.Services.AddScoped<DocumentStatusRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<CategoryRepository>();
builder.Services.AddControllersWithViews();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Index");
}
app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
