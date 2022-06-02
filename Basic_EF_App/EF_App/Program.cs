// Create a builder
using EF_App.Context;
using EF_App.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add a connection to Db
//var connectionString = builder.Configuration.GetConnectionString("AppDb");
var connectionString = builder.Configuration.GetSection("SQLConn").Value;
builder.Services.AddDbContext<WeatherForecastDbContext>(x => x.UseSqlServer(connectionString));


// Add the dataseeder service
builder.Services.AddTransient<DataSeeder>();

// Add the DAL interface and connect it to the DAL
builder.Services.AddScoped<IWeatherForecastDAL, WeatherForecastDAL>();

// Add the Swagger Service
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Build the app
var app = builder.Build();

// Automatically Migrate the database
using (var scope = app.Services.CreateScope())
{
    var y = scope.ServiceProvider.GetRequiredService<WeatherForecastDbContext>();
    y.Database.Migrate();
}

// IF 'dotnet run seeddata' is run, the app wil seed data
if (args.Length == 1 && args[0].ToLower() == "seeddata")
{
    SeedData(app);
}

// Method for seeding data
void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<DataSeeder>();
        service.Seed();
    }
}

// IF we are developing, add a swagger UI and exceptionsPage
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.MapGet("/", () =>
{
    return "Hello World!";
});

app.MapGet("/weatherforecasts", ([FromServices] IWeatherForecastDAL db) =>
{
    if (db.GetWeatherForecast().ToArray().Length == 0)
    {
        SeedData(app);
    }
    return db.GetWeatherForecast();
});


// Run the app
app.Run();