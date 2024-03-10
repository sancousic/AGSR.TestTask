using AGSR.Patients.Domain.Context;
using AGSR.Patients.Domain.Extensions;
using AGSR.Patients.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddConfigDbContext();
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo { Title = "AGSR.Patients", Description = "Test task", Version = "v1" });
        options.ResolveConflictingActions(apiDescription => apiDescription.First());
        options.IgnoreObsoleteActions();
        options.IgnoreObsoleteProperties();
        options.CustomSchemaIds(type => type.FullName);

        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    });

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await AddMigrations(app);

app.Run();

async Task AddMigrations(WebApplication webApplication)
{
    using var scope = webApplication.Services.CreateScope();

    var context = scope.ServiceProvider.GetRequiredService<ConfigContext>();
    await context.Database.MigrateAsync();
}
