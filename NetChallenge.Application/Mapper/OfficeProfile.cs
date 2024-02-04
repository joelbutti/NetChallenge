using AutoMapper;
using NetChallenge.Application.UseCases.Commands.AddLocation;
using NetChallenge.Application.UseCases.Commands.AddOffice;
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
    public class OfficeProfile : Profile
    {
        public OfficeProfile()
        {
            CreateMap<AddOfficeRequest, AddOfficeCommand>().ReverseMap();
            CreateMap<AddOfficeRequest, Office>().ReverseMap();
            CreateMap<OfficeDto, Office>().ReverseMap();
        }
    }
}
