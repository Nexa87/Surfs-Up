using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SurfsUpv3.Data;
using SurfsUpv3.Models;
using Microsoft.Extensions.DependencyInjection;
using SurfsUpv3.Middleware;
using SurfsUpv3.Controllers;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<SurfsUpv3Context>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")));

// Add services to the container.

builder.Services.AddHttpClient();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddControllers();
//builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<>

//builder.Services.AddDbContext<SurfsUpv3Context>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.UseStatusCodePagesWithReExecute("/404");
app.UseLog404s();

// Inds�tter surfboards i databasen (er det ikke 'dotnet ef database add/update' der g�r det ?)
//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;

//    SurfboardDataSeed.Initialize(services);
//}



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.MapControllers();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
