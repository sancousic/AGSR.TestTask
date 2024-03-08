using AGSR.Patients.Domain.Context;
using AGSR.Patients.Domain.Extensions;
using AGSR.Patients.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddConfigDbContext();
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
