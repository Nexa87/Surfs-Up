using Microsoft.OpenApi.Models;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using SurfsUpWebApp.Models;
namespace SurfsUpWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "SurfsUPAPI",
                    Description = "The boards you love",
                    Version = "v1"
                });
            });

            builder.Services.AddDbContext<SurfboardDb>(options => options.UseInMemoryDatabase("surfboards"));

            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "PizzaStore API V1");
                });
            }


            //app.MapGet("/", () => "Hello World!");


            app.MapGet("/Surfboard", async (SurfboardDb db) => await db.Surfboards.ToListAsync());

            app.MapPost("/Surfboard", async (Surfboard surfboard, SurfboardDb db) =>
            {
                await db.Surfboards.AddAsync(surfboard);
                await db.SaveChangesAsync();
                return Results.Created($"/Surfboard/{surfboard.SurfboardId}", surfboard);
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
