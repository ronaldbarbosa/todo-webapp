using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TodoList.Data;
using TodoList.Models;
using TodoList.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<TodoListDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("LocalDb")));

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<TodoListDbContext>();

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<TodoTaskService>();
builder.Services.AddScoped<TodoTaskListService>();
builder.Services.AddScoped<TagService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
