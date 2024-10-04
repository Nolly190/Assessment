using Assessment.Application;
using Assessment.Application.Dtos;
using Assessment.Application.FluentValidators.BookController;
using Assessment.Application.Implementation;
using Assessment.Application.Interfaces;
using Assessment.Application.ViewModels;
using Assessment.Infrastructure.Context;
using Assessment.Worker.Jobs;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;

namespace Assessment.Worker.ServiceExtentions
{
    public static class ServiceExtention
    {
        public static void AddWorkerServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
            services.AddQuartz(q =>
            {

                q.UseMicrosoftDependencyInjectionJobFactory();
                var jobKey = new JobKey($"ReservationCheck-job");

                q.AddJob<ReservationCheckJob>(c =>
                {
                    c.WithIdentity(jobKey);
                });

                q.AddTrigger(q => {
                    q.WithIdentity($"ReservationCheck-trigger");
                    q.WithCronSchedule("0 0/5 * 1/1 * ? *");
                    q.ForJob(jobKey);
                    q.WithDescription("This worker service checks for all reserved books yet to be collected after 24 hours");
                });

            });
            services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

        }
    }
}
