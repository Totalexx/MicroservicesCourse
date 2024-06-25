using Infastructed;
using Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.TryAddInfrastructure();
builder.Services.TryAddServices();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
