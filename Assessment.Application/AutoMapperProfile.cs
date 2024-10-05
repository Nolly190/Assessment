using Assessment.Application.Dtos;
using Assessment.Application.Helpers;
using Assessment.Application.ViewModels;
using Assessment.Domain.Entities;
using AutoMapper;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Application
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddBookViewModel, Book>();
            CreateMap<Book, BookViewModel>()
                .ForMember(x => x.Status, opt => opt.MapFrom(c => c.Status.Description()));
            CreateMap<ValidationFailure, Error>()
                .ForMember(x => x.Field, opt => opt.MapFrom(c => c.PropertyName))
                .ForMember(x => x.Description, opt => opt.MapFrom(c => c.ErrorMessage));


            CreateMap<User, UserViewModel>();
            CreateMap<BookReservation, ReservationViewModel>();
            CreateMap<BookReservationNotification, ReservationNotificationViewModel>();
            CreateMap<BookReservationViewModel, BookReservation>();
            CreateMap<BookCollectionViewModel, BookReservation>();
            CreateMap<BookReservationViewModel, BookReservationNotification>();
            CreateMap<RegistrationRequestViewModel, User>();


        }
    }
}
