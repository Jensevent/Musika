using MassTransit;
using SharedLibrary;

var builder = WebApplication.CreateBuilder(args);

// RabbitMQ
RabbitMQ_settings settings = new RabbitMQ_settings();

builder.Services.AddMassTransit(config => {
    config.UsingRabbitMq((ctx, cfg) =>
    {
        // Connect to RabbitMQ server;
        cfg.Host("amqp://" + settings.Username + ":" + settings.Password + "@" + settings.IPAddress);
    });
});
builder.Services.AddMassTransitHostedService();


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




var app = builder.Build();

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
