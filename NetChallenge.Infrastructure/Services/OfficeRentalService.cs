using AutoMapper;
using Azure.Core;
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

        public OfficeRentalService(ILocationRepository locationRepository, IOfficeRepository officeRepository, IBookingRepository bookingRepository)
        {
            _locationRepository = locationRepository;
            _officeRepository = officeRepository;
            _bookingRepository = bookingRepository;
        }

        public void AddLocation(AddLocationRequest request)
        {
            var locations = _locationRepository.AsEnumerable();

            if (locations.Any(l => l.Name == request.Name))
                throw new InvalidOperationException($"There is already a location with the name '{request.Name}'");

            var entity = Location.Create(request.Name, request.Neighborhood);

            _locationRepository.Add(entity);
        }

        public async Task AddLocationDb(AddLocationRequest request)
        {
            var entity = Location.Create(request.Name, request.Neighborhood);

            await _locationRepository.AddDb(entity);
        }

        public void AddOffice(AddOfficeRequest request)
        {
            var location = _locationRepository.AsEnumerable().FirstOrDefault(loc => loc.Name == request.LocationName)!
                ?? throw new InvalidOperationException($"Location '{request.LocationName}' not found.");

            if(location.Offices.Any(o => o.Name == request.Name))
                throw new InvalidOperationException($"There is already a office in location {location.Name} with the name '{request.Name}'");

            var entity = Office.Create(location.Id, request.Name, request.MaxCapacity, request.AvailableResources.ToList());

            location.Offices.Add(entity);

            _officeRepository.Add(entity);
        }

        public async Task AddOfficeDb(AddOfficeRequest request)
        {
            var location = _locationRepository.AsEnumerable().FirstOrDefault(loc => loc.Name == request.LocationName)!
                    ?? throw new InvalidOperationException($"Location '{request.LocationName}' not found.");

            var entity = Office.Create(location.Id, request.Name, request.MaxCapacity, request.AvailableResources.ToList());

            await _officeRepository.AddDb(entity);
        }

        public void BookOffice(BookOfficeRequest request)
        {
            var location = _locationRepository.AsEnumerable()
                .FirstOrDefault(l => l.Name == request.LocationName) ?? throw new InvalidOperationException($"Location '{request.LocationName}' not found.");

            var office = location.Offices
                .Find(o => o.Name == request.OfficeName) ?? throw new InvalidOperationException($"Office '{request.OfficeName}' in Location '{request.LocationName}' not found.");

            var overlappingBooking = _bookingRepository.AsEnumerable()
                .FirstOrDefault(b => b.OfficeId == office.Id &&
                                      request.DateTime < b.DateTime.Add(b.Duration) &&
                                      request.DateTime.Add(request.Duration) > b.DateTime);

            if (overlappingBooking != null)
                throw new InvalidOperationException("Booking overlaps with an existing reservation.");

            var booking = Booking.Create(office.Id, request.DateTime, request.Duration, request.UserName);

            office.Bookings.Add(booking);

            _bookingRepository.Add(booking);
        }

        public async Task BookOfficeDb(BookOfficeRequest request)
        {
            var location = _locationRepository.AsEnumerableDb()
                .FirstOrDefault(l => l.Name == request.LocationName) ?? throw new InvalidOperationException($"Location '{request.LocationName}' not found.");

            var office = location.Offices
                .Find(o => o.Name == request.OfficeName) ?? throw new InvalidOperationException($"Office '{request.OfficeName}' in Location '{request.LocationName}' not found.");

            var overlappingBooking = _bookingRepository.AsEnumerableDb()
                .FirstOrDefault(b => b.OfficeId == office.Id &&
                                      request.DateTime < b.DateTime.Add(b.Duration) &&
                                      request.DateTime.Add(request.Duration) > b.DateTime);

            if (overlappingBooking != null)
                throw new InvalidOperationException("Booking overlaps with an existing reservation.");

            var booking = Booking.Create(office.Id, request.DateTime, request.Duration, request.UserName);

            await _bookingRepository.AddDb(booking);
        }

        public IEnumerable<BookingDto> GetBookings(string locationName, string officeName)
        {
            var location = _locationRepository.AsEnumerable()
            .FirstOrDefault(l => l.Name == locationName) ?? throw new InvalidOperationException($"Location '{locationName}' not found.");

            var office = _officeRepository.AsEnumerable()
            .FirstOrDefault(o => o.Name == officeName) ?? throw new InvalidOperationException($"Office '{officeName}' in Location '{locationName}' not found.");

            var bookings = office.Bookings.Select(o =>
            {
                return new BookingDto()
                {
                    DateTime = o.DateTime,
                    Duration = o.Duration,
                    UserName= o.UserName,
                    LocationName = location.Name,
                    OfficeName = office.Name
                };
            });

            return bookings;
        }

        public IEnumerable<BookingDto> GetBookingsDb(string locationName, string officeName)
        {
            var location = _locationRepository.AsEnumerableDb()
            .FirstOrDefault(l => l.Name == locationName) ?? throw new InvalidOperationException($"Location '{locationName}' not found.");

            var office = _officeRepository.AsEnumerableDb()
            .FirstOrDefault(o => o.Name == officeName) ?? throw new InvalidOperationException($"Office '{officeName}' in Location '{locationName}' not found.");

            var bookings = office.Bookings.Select(o =>
            {
                return new BookingDto()
                {
                    DateTime = o.DateTime,
                    Duration = o.Duration,
                    UserName = o.UserName,
                    LocationName = location.Name,
                    OfficeName = office.Name
                };
            });

            return bookings;
        }

        public IEnumerable<LocationDto> GetLocations()
        {
            var entities = _locationRepository.AsEnumerable();

            return entities.Select(l =>
            {
                return new LocationDto()
                {
                    Name = l.Name,
                    Neighborhood = l.Neighborhood
                };
            });
        }

        public IEnumerable<LocationDto> GetLocationsDb()
        {
            var entities = _locationRepository.AsEnumerableDb();

            return entities.Select(l =>
            {
                return new LocationDto()
                {
                    Name = l.Name,
                    Neighborhood = l.Neighborhood
                };
            });
        }

        public IEnumerable<OfficeDto> GetOffices(string locationName)
        {
            var location = _locationRepository.AsEnumerable().FirstOrDefault(loc => loc.Name == locationName);

            if (location == null)
            {
                return Enumerable.Empty<OfficeDto>();
            }

            var offices = location.Offices.Select(o =>
            {
                return new OfficeDto()
                {
                    Name= o.Name,
                    AvailableResources = o.AvailableResources.ToArray(),
                    LocationName = location.Name,
                    MaxCapacity = o.MaxCapacity
                };
            });

            return offices;
        }

        public IEnumerable<OfficeDto> GetOfficesDb(string locationName)
        {
            var location = _locationRepository.AsEnumerableDb().FirstOrDefault(loc => loc.Name == locationName);

            if (location == null)
            {
                return Enumerable.Empty<OfficeDto>();
            }

            var offices = location.Offices.Select(o =>
            {
                return new OfficeDto()
                {
                    Name = o.Name,
                    AvailableResources = o.AvailableResources.ToArray(),
                    LocationName = location.Name,
                    MaxCapacity = o.MaxCapacity
                };
            });

            return offices;
        }

        public IEnumerable<OfficeDto> GetOfficeSuggestions(SuggestionsRequest request)
        {
            var offices = _officeRepository.AsEnumerable();
            var locations = _locationRepository.AsEnumerable();

            offices = offices.Where(office => office.MaxCapacity >= request.CapacityNeeded);

            offices = offices.Where(office => request.ResourcesNeeded.All(resource => office.AvailableResources.Contains(resource)));

            offices = offices.OrderByDescending(office =>
            {
                var location = locations.FirstOrDefault(l => l.Id == office.LocationId)!;

                int convenienceScore = 0;

                if (location.Neighborhood == request.PreferedNeigborHood) convenienceScore = 100;

                convenienceScore -= (office.MaxCapacity - request.CapacityNeeded);
                convenienceScore -= (office.AvailableResources.Count - request.ResourcesNeeded.Count());

                return convenienceScore;
            });

            var officesDto = offices.Select(office =>
            {
                var location = locations.FirstOrDefault(x => x.Id == office.LocationId)!;

                return new OfficeDto()
                {
                    LocationName = location.Name,
                    Name = office.Name,
                    MaxCapacity = office.MaxCapacity,
                    AvailableResources = [.. office.AvailableResources]
                };
            });

            return officesDto;
        }

        public IEnumerable<OfficeDto> GetOfficeSuggestionsDb(SuggestionsRequest request)
        {
            var offices = _officeRepository.AsEnumerableDb();
            var locations = _locationRepository.AsEnumerableDb();

            offices = offices.Where(office => office.MaxCapacity >= request.CapacityNeeded);

            offices = offices.Where(office => request.ResourcesNeeded.All(resource => office.AvailableResources.Contains(resource)));

            offices = offices.OrderByDescending(office =>
            {
                var location = locations.FirstOrDefault(l => l.Id == office.LocationId)!;

                int convenienceScore = 0;

                if (location.Neighborhood == request.PreferedNeigborHood) convenienceScore = 100;

                convenienceScore -= (office.MaxCapacity - request.CapacityNeeded);
                convenienceScore -= (office.AvailableResources.Count - request.ResourcesNeeded.Count());

                return convenienceScore;
            });

            var officesDto = offices.Select(office =>
            {
                var location = locations.FirstOrDefault(x => x.Id == office.LocationId)!;

                return new OfficeDto()
                {
                    LocationName = location.Name,
                    Name = office.Name,
                    MaxCapacity = office.MaxCapacity,
                    AvailableResources = [.. office.AvailableResources]
                };
            });

            return officesDto;
        }
    }
}
