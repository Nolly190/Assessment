using Assessment.Application.FluentValidators.BookController;
using Assessment.Application.Implementation;
using Assessment.Application.Interfaces;
using Assessment.Application.ViewModels;
using Assessment.Infrastructure.Context;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Assessment.Application.ServiceExtentions
{
    public static class ServiceExtention
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Automatically injects all assembly of type BookValidator FluentValidation
            services.AddValidatorsFromAssemblyContaining<BookValidator>();
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddScoped<IBookService,BookService>();
            services.AddScoped<IReservationService,ReservationService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
        }
    }
}
