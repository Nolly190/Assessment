using Assessment.Application.ServiceExtentions;
using Assessment.Infrastructure.Context;
using Assessment.Infrastructure.ServiceExtentions;
using Assessment.Middleware;
using Assessment.ServiceExtentions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration;
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAPIServices(configuration);
builder.Services.AddInfrastructureServices(configuration);
builder.Services.AddApplicationServices(configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionHandler>();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
