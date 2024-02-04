using NetChallenge.Dto.Output;
using NetChallenge.Dtos.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Application.Abstractions
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
