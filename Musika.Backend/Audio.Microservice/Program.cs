using Audio.Microservice.Context;
using Audio.Microservice.Data;
using Audio.Microservice.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// Create a builder
var builder = WebApplication.CreateBuilder(args);

// Add a connection to Db
var connectionString = builder.Configuration.GetConnectionString("AppDb");
builder.Services.AddDbContext<AudioDbContext>(x => x.UseSqlServer(connectionString));

// Add the dataseeder service
builder.Services.AddTransient<DataSeeder>();

// Add the DAL interface and connect it to the DAL
builder.Services.AddScoped<IAudioDAL, AudioDAL>();

// Add the Swagger Service
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Build the app
var app = builder.Build();

// Automatically Migrate the database
using (var scope = app.Services.CreateScope())
{
    var y = scope.ServiceProvider.GetRequiredService<AudioDbContext>();
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

// Easy check to see if API works
app.MapGet("/", () =>
{
    string[] x = new string[]{ connectionString,  Environment.GetEnvironmentVariable("ConnectionStrings:AppDb")};
    return x;

    //return "Hello World!";
});

// GET all songs
app.MapGet("/audio", ([FromServices] IAudioDAL db) =>
{
    return db.GetSongs();
});


app.MapPost("/upload", (HttpRequest request) =>
{
    // Get all files from the request
    var files = request.Form.Files;

    // For each file, start the upload process
    foreach (var file in files)
    {
        // Get the file extension
        var extension = new FileInfo(file.FileName).Extension;

        // Generate a new file name
        string name = Guid.NewGuid() + extension;

        // Connect to my FTP server
        var client = new FluentFTP.FtpClient("192.168.150.128", "testuser", "root");
        client.AutoConnect();
        
        // Turn the file into a byte[]
        var ms = new MemoryStream();
        file.CopyTo(ms);
        ms.Close();
        var array = ms.ToArray();

        // Upload the file to FTP
        var x =  client.Upload(array, name);

        // Disconnect the client
        client.Disconnect();
    }
});

app.MapGet("/download", () =>
{
    // Connect to FTP server
    var client = new FluentFTP.FtpClient("192.168.150.128", "testuser", "root");
    client.AutoConnect();

    // Creating a new memory stream to save the file to
    var ms = new MemoryStream();

    // Download the file to the memory stream
    client.Download(ms,"1bd792f4-9582-4f26-b69b-19a6a7e8884e.png");
    
    // Turn the memory stream into a byte[]
    var array = ms.ToArray();

    // Close the memory stream
    ms.Close();

    // Close the FTP connection
    client.Disconnect();

    // Return the file to the user
    return Results.File(array, contentType: "image/png");
});


// Run the app
app.Run();