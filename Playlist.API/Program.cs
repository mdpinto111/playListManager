using Playlist.API.Models;
using Playlist.API.Services;
using Playlist.API.Controllers;
using NLog;
using NLog.Web;

//NLog
var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<PlaylistDatabaseSettings>(
    builder.Configuration.GetSection("PlaylistDatabase"));

builder.Services.AddScoped<IPlaylistService, PlaylistService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// jwt
builder.Services.AddAuthentication()
                .AddJwtBearer();

//NLog
builder.Services.AddControllersWithViews();
builder.Logging.ClearProviders();
builder.Host.UseNLog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// jwt
app.UseAuthorization();

app.MapControllers();

app.Run();
