using CoensioEvulatorApi.Data;
using CoensioEvulatorApi.EventProcessing;
using CoensioEvulatorApi.Repositories.Abstracts;
using CoensioEvulatorApi.Repositories.Concretes;
using CommandsService.AsyncDataServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Console.WriteLine("Database Connection String: " + builder.Configuration["Database"]);
Console.WriteLine("RabbitMQ Host: " + builder.Configuration["RabbitMQHost"]);
Console.WriteLine("RabbitMQ Port: " + builder.Configuration["RabbitMQPort"]);
Console.WriteLine("Redis Connection String: " + builder.Configuration["Redis"]);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<ApiDbContext>(opt => opt.UseNpgsql(builder.Configuration["Database"]));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHostedService<MessageBusSubscriber>();
builder.Services.AddSingleton<IEventProcessor, EventProcessor>();
builder.Services.AddScoped<IEvaluationRepository, EvaluationRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
