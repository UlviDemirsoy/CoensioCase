using CoensioApi.Data;
using CoensioApi.Data.Models;
using CoensioApi.Repositories.Abstracts;
using CoensioApi.Repositories.Concretes;
using CoensioApi.Services.Abstracts;
using CoensioApi.Services.Concretes;
using CoensioAPI.Extensions;
using CoensioAPI.Services.Concretes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
// Add services to the container.

// Access and write the connection strings to the console

//Jwt configuration starts here
var jwtIssuer = builder.Configuration.GetSection("Jwt:Issuer").Get<string>();
var jwtKey = builder.Configuration.GetSection("Jwt:Key").Get<string>();

Console.WriteLine("Database Connection String: " + builder.Configuration["Database"]);
Console.WriteLine("RabbitMQ Host: " + builder.Configuration["RabbitMQHost"]);
Console.WriteLine("RabbitMQ Port: " + builder.Configuration["RabbitMQPort"]);
Console.WriteLine("Redis Connection String: " + builder.Configuration["Redis"]);


builder.Services.AddDbContext<ApiDbContext>(opt => opt.UseNpgsql(builder.Configuration["Database"]));
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IMessageProducer, MessageProducer>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITestService, TestService>();
builder.Services.AddScoped<IAssignmentService, AssignmentService>();
builder.Services.AddScoped<IAssignmentRepository, AssignmentRepository>();
builder.Services.AddScoped<ITestRepository, TestRepository>();
builder.Services.AddScoped<ICodingQuestionRepository, CodingQuestionRepository>();
builder.Services.AddScoped<ICodingQuestionService, CodingQuestionService>();
builder.Services.AddScoped<ICodingQuestionTestTakerAnswerRepository, CodingQuestionTestTakerAnswerRepository>();
builder.Services.AddScoped<IMultipleChoiceQuestionRepository, MultipleChoiceQuestionRepository>();
builder.Services.AddScoped<IMultipleChoiceQuestionService, MultipleChoiceQuestionService>();
builder.Services.AddScoped<IMultipleChoiceQuestionTestTakerAnswerRepository, MultipleChoiceQuestionTestTakerAnswerRepository>();
builder.Services.AddScoped<IFreeTextQuestionRepository, FreeTextQuestionRepository>();
builder.Services.AddScoped<IFreeTextQuestionService, FreeTextQuestionService>();
builder.Services.AddScoped<IFreeTextQuestionTestTakerAnswerRepository, FreeTextQuestionTestTakerAnswerRepository>();
builder.Services.AddTransient<IJwtTokenService, JwtTokenService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
 .AddJwtBearer(options =>
 {
     options.TokenValidationParameters = new TokenValidationParameters
     {
         ValidateIssuer = false,
         ValidateAudience = false,
         ValidateLifetime = false,
         ValidateIssuerSigningKey = true,
         ValidIssuer = jwtIssuer,
         ValidAudience = jwtIssuer,
         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
     };
 });

//Jwt configuration ends here

builder.Services.AddScoped<ICacheService, RedisService>();
builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    opt.JsonSerializerOptions.WriteIndented = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setup =>
{
    // Include 'SecurityScheme' to use JWT Authentication
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { jwtSecurityScheme, Array.Empty<string>() }
    });

});
var app = builder.Build();
var logger = app.Services.GetRequiredService<ILogger<Program>>();

logger.LogInformation($"Connection String: {builder.Configuration["Database"]}");


// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.Migrate();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


//app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
