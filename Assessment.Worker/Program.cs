using Assessment.Application.ServiceExtentions;
using Assessment.Infrastructure.ServiceExtentions;
using Assessment.Worker.ServiceExtentions;
using Quartz;

var builder = Host.CreateApplicationBuilder(args); 
var configuration = builder.Configuration;
builder.Services.AddWorkerServices(configuration);
builder.Services.AddInfrastructureServices(configuration);
var host = builder.Build();
host.Run();
