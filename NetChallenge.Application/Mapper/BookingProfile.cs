using AutoMapper;
using NetChallenge.Application.UseCases.Commands.AddBook;
using NetChallenge.Domain.Entities;
using NetChallenge.Dto.Output;
using NetChallenge.Dtos.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Application.Mapper
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<AddBookCommand, BookOfficeRequest>().ReverseMap();
            CreateMap<BookOfficeRequest, Booking>().ReverseMap();
            CreateMap<Booking, BookingDto>().ReverseMap();
        }
    }
}
