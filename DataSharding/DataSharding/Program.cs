using DataSharding.Data;
using DataSharding.Model;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddScoped<iMovieDAL, MovieDAL>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Build the app
var app = builder.Build();

// IF we are developing, add a swagger UI and exceptionsPage
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}


// Get Hello world!
app.MapGet("/", () =>
{
    return "Hello World!";
});

// Get a movie based on its title
app.MapGet("/get", ([FromServices] iMovieDAL db, string title) =>
{
    return db.GetMovie(title);
});

// Add a new movie
app.MapPost("/add", ([FromServices] iMovieDAL db, Movie movie) =>
{
    return db.AddMovie(movie);
});

// Initialize the database and seed some data into it
app.MapGet("/initDB", ([FromServices] iMovieDAL db) =>
{
    return db.InitDatabase();
});



// Run the app
app.Run();