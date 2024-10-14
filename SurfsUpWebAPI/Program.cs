using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SurfsUpWebAPI.Data;
using Swashbuckle.AspNetCore.Filters;
using SurfsUpWebAPI.Models;
using SurfsUpWebAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<SurfsUpAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllers();
builder.Services.AddScoped<ILoggingService, LoggingService> (); // Register the service here

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAuthentication();

builder.Services.AddAuthorization();

builder.Services.AddHttpClient();

builder.Services.AddCors(options =>
{
    //Mobil app
    options.AddPolicy("MobileApp", policyBuilder =>
    {
        policyBuilder.WithOrigins("http://localhost:9999");
        policyBuilder.AllowAnyHeader();
        policyBuilder.AllowAnyMethod();
        policyBuilder.AllowCredentials();
    });
      
    
});

var app = builder.Build();

//app.UseMiddleware<HowManyAPIRequest>(); // v1, replaced by below 'app.UseHowManyHowMany();'
app.UseHowManyAPIRequests(); // Custom not-pretty but recognizable :D
app.UseStatusCodePages(); // Needed for 404 tracking, middleware

// Configure the HTTP request pipeline.

//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;

//    SurfboardDataSeed.Initialize(services);
//}

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapIdentityApi<IdentityUser>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("MobileApp");

app.Run();
