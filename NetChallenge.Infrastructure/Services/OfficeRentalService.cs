using AutoMapper;
using NetChallenge.Application.Abstractions;
using NetChallenge.Domain.Entities;
using NetChallenge.Dto.Output;
using NetChallenge.Dtos.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Infrastructure.Services
{
    public class OfficeRentalService : IOfficeRentalService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IOfficeRepository _officeRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;

        public OfficeRentalService(ILocationRepository locationRepository, IOfficeRepository officeRepository, IBookingRepository bookingRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _officeRepository = officeRepository;
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }

        public async Task AddLocation(AddLocationRequest request)
        {
            var entity = _mapper.Map<Location>(request);
            entity.Id = Guid.NewGuid();

            await _locationRepository.Add(entity);
        }

        public async Task AddOffice(AddOfficeRequest request)
        {
            var location = _locationRepository.AsEnumerable().FirstOrDefault(loc => loc.Name == request.LocationName)!
                ?? throw new InvalidOperationException($"Location '{request.LocationName}' not found.");

            var entity = _mapper.Map<Office>(request);
            entity.LocationId = location.Id;

            await _officeRepository.Add(entity);
        }

        public Task BookOffice(BookOfficeRequest request)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookingDto> GetBookings(string locationName, string officeName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LocationDto> GetLocations()
        {
            var entities = _locationRepository.AsEnumerable();

            return _mapper.Map<IEnumerable<LocationDto>>(entities);
        }

        public IEnumerable<OfficeDto> GetOffices(string locationName)
        {
            var location = _locationRepository.AsEnumerable().FirstOrDefault(loc => loc.Name == locationName);

            if (location == null)
            {
                return Enumerable.Empty<OfficeDto>();
            }

            var offices = _mapper.Map<IEnumerable<OfficeDto>>(location.Offices);

            foreach (var office in offices)
            {
                office.LocationName = location.Name;
            }

            return offices;
        }


        public IEnumerable<OfficeDto> GetOfficeSuggestions(SuggestionsRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
