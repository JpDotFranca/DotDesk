using DotDesk.Application;
using DotDesk.Application.Services.Abstraction;
using DotDesk.Application.Services;
using DotDesk.Infraestucture.Repositories.Abstraction;
using DotDesk.Infrastructure.Configurations;
using DotDesk.Infrastructure.Repositories;
using DotDesk.Api.Hubs;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Configure MongoDB Settings
builder.Services.AddControllers();
builder.Services.AddScoped<IChatRepository, MongoChatRepository>();
builder.Services.AddScoped<IChatService, ChatService>();
 
builder.Services.AddSignalR();
builder.Services.AddCors(options =>
{
    // Only for localhost
    options.AddPolicy("AllowAll",
        builder => builder
            .AllowAnyMethod()
            .AllowAnyHeader()
            .SetIsOriginAllowed(_ => true)
            .AllowCredentials()
    );

    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://127.0.0.1:5500")
              .AllowAnyHeader() 
              .AllowAnyMethod()
              .AllowCredentials(); // Required for SignalR
    });
});

// Register MongoDB Client and Database
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));
builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    return new MongoClient(settings.ConnectionString);
});
builder.Services.AddScoped<IMongoDatabase>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    var client = sp.GetRequiredService<IMongoClient>();
    return client.GetDatabase(settings.DatabaseName);
});
 

builder.Services.AddApplicationServices()
                .AddInfraestructureRepositories(builder.Configuration);

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("AllowAll");
app.UseCors();

app.MapControllers();
app.MapHub<WebChatHub>("/chat");

app.Run();

