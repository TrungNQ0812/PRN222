using Microsoft.EntityFrameworkCore;
using NguyenQuangTrungRazorPages.DAL;
using NguyenQuangTrungRazorPages.Models;
using NguyenQuangTrungRazorPages.Repositories;
using NguyenQuangTrungRazorPages.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FuNewsManagementContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("FuNewsManagement")));

builder.Services.AddScoped<FuNewsManagementContext>();
builder.Services.Configure<AdminAccountSettings>(builder.Configuration.GetSection("AdminAccount"));
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<INewsRepository, NewsRepository>();
builder.Services.AddScoped<INewsService, NewsService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<ITagService, TagService>();
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
