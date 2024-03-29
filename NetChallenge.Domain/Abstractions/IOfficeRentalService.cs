﻿using NetChallenge.Dto.Output;
using NetChallenge.Dtos.Input;

namespace NetChallenge.Domain.Abstractions
{
    public interface IOfficeRentalService
    {
        void AddLocation(AddLocationRequest request);
        void AddOffice(AddOfficeRequest request);
        void BookOffice(BookOfficeRequest request);
        IEnumerable<BookingDto> GetBookings(string locationName, string officeName);
        IEnumerable<LocationDto> GetLocations();
        IEnumerable<OfficeDto> GetOffices(string locationName);
        IEnumerable<OfficeDto> GetOfficeSuggestions(SuggestionsRequest request);
        Task AddLocationDb(AddLocationRequest request);
        Task AddOfficeDb(AddOfficeRequest request);
        Task BookOfficeDb(BookOfficeRequest request);
        IEnumerable<BookingDto> GetBookingsDb(string locationName, string officeName);
        IEnumerable<LocationDto> GetLocationsDb();
        IEnumerable<OfficeDto> GetOfficesDb(string locationName);
        IEnumerable<OfficeDto> GetOfficeSuggestionsDb(SuggestionsRequest request);
    }
}
