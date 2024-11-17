using LearningRabbitMQ.Controllers;
using LearningRabbitMQ.Extensions;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRabbitMQService();
builder.WebHost.ConfigureKestrel(oprions =>
{
    oprions.ListenAnyIP(80);
    oprions.ListenAnyIP(443);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.AddApiEndpoints();
app.UseHttpsRedirection();

app.Run();

