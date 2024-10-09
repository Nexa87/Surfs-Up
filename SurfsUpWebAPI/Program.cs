using SurfsUpWebAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging(); // Needed for client & 404 middleware

var app = builder.Build();

//app.UseMiddleware<HowManyAPIRequest>(); // v1, replaced by below 'app.UseHowManyHowMany();'
app.UseHowManyAPIRequests(); // Custom not-pretty but recognizable :D
app.UseStatusCodePages(); // Needed for 404 tracking, middleware

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
