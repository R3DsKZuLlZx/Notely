using Carter;
using Notely.Application;
using Notely.Infrastructure;
using Notely.Web;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add logging.
var logger = new LoggerConfiguration()
    .ConfigureDefaultSerilog(builder.Environment.IsDevelopment())
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Services.AddSerilog(logger);

// Add configuration files.
var env = builder.Environment;
var sharedAppSettings = Path.Combine(env.ContentRootPath, "../../cfg/SharedAppSettings.json");
var sharedAppSettingsEnv = Path.Combine(env.ContentRootPath, $"../../cfg/SharedAppSettings.{env.EnvironmentName}.json");

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath);
builder.Configuration.AddJsonFile(sharedAppSettings, true, false);
builder.Configuration.AddJsonFile(sharedAppSettingsEnv, true, false);
builder.Configuration.AddEnvironmentVariables();

// Add services to the container.
builder.Services.AddNotelyApplication(builder.Configuration);
builder.Services.AddNotelyInfrastructure(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDocument();
builder.Services.AddCarter();

var app = builder.Build();

app.UseSerilogRequestLogging();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi3();
}

app.UseHttpsRedirection();

app.MapCarter();

app.MapHealthChecks("/api/health");

app.Run();
