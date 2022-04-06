using Musika.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add DB connection
//var connectionString = builder.Configuration.GetConnectionString("AppDb");
var connectionString = "Server=192.168.0.44;Database=master;User Id=sa;Password=Welkom12345;";
builder.Services.AddDbContext<EmployeeDbContext>(x => x.UseSqlServer(connectionString));

// Add dataSeeder
builder.Services.AddTransient<DataSeeder>();

// Add DataRepo as interface
// When the IDataRepository is called, it will use DataRepository
builder.Services.AddScoped<IDataRepository, DataRepository>();

// Implimenting Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Add Swagger UI
app.UseSwaggerUI();
app.UseSwagger(x => x.SerializeAsV2 = true);

// if 'dotnet run seeddata' is called, run the SeedData method
if (args.Length == 1 && args[0].ToLower() == "seeddata")
{
    SeedData(app);
}

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<DataSeeder>();
        service.Seed();
    }
}


// Dev
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}


// Get Employee by Id
app.MapGet("/employee/{id}", ([FromServices] IDataRepository db, string id) =>
{
    return db.GetEmployee(id);

});

// Return all employees in the database
app.MapGet("/employees", ( [FromServices] IDataRepository db) =>
{
    return db.GetEmployees();

});

// Update an existing employee
app.MapPut("/employee/{id}", ([FromServices] IDataRepository db, Employee employee) =>
{
    return db.PutEmployee(employee);
});


// Add a new employee
app.MapPost("/employee", ([FromServices] IDataRepository db, Employee employee) =>
{
    return db.AddEmployee(employee);
});


app.MapGet("/dbconn", ([FromServices] IDataRepository db) =>
{
    return db.CheckDbConn();
});

// Run the app
app.Run();