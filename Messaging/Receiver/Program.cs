using MassTransit;
using Receiver;
using SharedLibrary;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
RabbitMQ_settings settings = new RabbitMQ_settings();

builder.Services.AddMassTransit(config => {
    // Add Consumer which reads the sent message;
    config.AddConsumer<SongConsumer>();
    config.UsingRabbitMq((ctx, cfg) =>
    {
        // Connect to RabbitMQ server;
        cfg.Host("amqp://" + settings.Username + ":" + settings.Password + "@" + settings.IPAddress);
        
        // Add endpoint which will recieve messages from the [model] queue, these messages will be returned in via Consumer class;
        // In here you will be able to change settings, like setting the queue messageretry interval and more;
        cfg.ReceiveEndpoint(settings.QueueName, c =>
        {
            c.ConfigureConsumer<SongConsumer>(ctx);
        });
    });
});
builder.Services.AddMassTransitHostedService();




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

app.Run();
