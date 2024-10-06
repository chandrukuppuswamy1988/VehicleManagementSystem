using Microsoft.EntityFrameworkCore;
using Vehicle.API.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<IBusesRepository, BusesRepository>();

builder.Services.AddDbContext<VehicleDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("VehicleDB"));
});

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSwagger();

// This middleware serves the Swagger documentation UI
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Vehicle.API");
});


app.Run();
