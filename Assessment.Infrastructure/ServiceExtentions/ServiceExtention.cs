using Assessment.Infrastructure.Context;
using Assessment.Infrastructure.External_Services.Implementation;
using Assessment.Infrastructure.External_Services.Interface;
using Assessment.Infrastructure.Repositories.Implementation;
using Assessment.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Infrastructure.ServiceExtentions
{
    public static class ServiceExtention
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DbConnection")));
            services.AddScoped<INotificationService,NotificationService>();
            services.AddScoped(typeof(IGenericQueryRepository<>), typeof(GenericQueryRepository<>));
            services.AddScoped(typeof(IGenericCommandRepository<>), typeof(GenericCommandRepository<>));
        }
    }
}
