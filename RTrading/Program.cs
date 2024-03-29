using RTading.Infrastructure.Database;
using RTrading.Infrastructure.Backgraund;
using RTrading.Infrastructure.Strategies;
using RTraiding.Application;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

// dependencies
services.AddApplication();
services.AddInfrastructureDataBase(configuration);
services.AddInfrastructureStrategies(configuration);
services.AddInfrastructureBackgraund();
//API
builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseWebSockets();
app.MapControllers();

app.Run();

