using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Vehicle.API.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<IBusesRepository, BusesRepository>();

builder.Services.AddDbContext<VehicleDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("VehicleDB"));
});

builder.Services.AddSwaggerGen(setupAction =>
{
    //Addes Title and Description for the API Swagger
    setupAction.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
    {
        Title = "Vehicle API",
        Description = "Through this API you can access Vehicle."
    });

    /// addes the comments to swagger methods.also check output of xml in properties setting of the projects
    var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);

    setupAction.IncludeXmlComments(xmlCommentsFullPath);

});

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
