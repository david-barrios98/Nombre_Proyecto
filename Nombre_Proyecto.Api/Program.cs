using NLog.Extensions.Logging;
using Nombre_Proyecto.Api.Extensions;
using Nombre_Proyecto.Infrastructure.DependencyInjection;
using Nombre_Proyecto.Infrastructure.Persistence.Adapters;
using Nombre_Proyecto.Infrastructure.Seed;

var builder = WebApplication.CreateBuilder(args);

// ================= CONFIG =================
var configuration = builder.Configuration;

// ================= SERVICES =================
builder.Services
    .AddApplicationServices()
    .AddInfrastructure()
    .AddDatabase(configuration)
    .AddJwtAuthentication(configuration)
    .AddCorsPolicy(configuration)
    .AddRateLimiting(configuration)
    .AddSwaggerDocumentation()
    .AddControllers();

// ================= LOGGING =================
builder.Logging.ClearProviders();
builder.Logging.AddNLog("nlog.config");

var app = builder.Build();

// ================= PIPELINE =================
app.UseGlobalMiddleware();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerDocumentation();
}

app.UseHttpsRedirection();
app.UseCors("_corsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// ================= SEED =================
await app.RunSeedIfNeeded(configuration);

app.Run();