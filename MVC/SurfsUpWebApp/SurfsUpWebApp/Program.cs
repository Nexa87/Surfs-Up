using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using SurfsUpWebApp.Models;

namespace SurfsUpWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("Surfboard") ?? "Data Source=Surfboards.db";
            //builder.Services.AddDbContext<SurfboardDb>(options => options.UseInMemoryDatabase("surfboards"));
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSqlite<SurfboardDb>(connectionString);
            builder.Services.AddControllersWithViews();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "SurfsUPAPI",
                    Description = "The boards you love",
                    Version = "v1"
                });
            });

           

            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SurfsUp API V1");
                });
            }

            // /Models/Surfboard
            app.MapGet("/Models/Surfboard", async (SurfboardDb db) => await db.Surfboards.ToListAsync());

            app.MapPost("/Models/Surfboard", async (Surfboard surfboard, SurfboardDb db) =>
            {
                await db.Surfboards.AddAsync(surfboard);
                await db.SaveChangesAsync();
                return Results.Created($"/Models/Surfboard/{surfboard.SurfboardId}", surfboard);
            });

            app.UseStaticFiles();

            app.UseRouting();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
                );

            app.Run();
        }

    }
}
