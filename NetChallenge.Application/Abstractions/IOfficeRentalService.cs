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
        Task AddLocation(AddLocationRequest request);
        Task AddOffice(AddOfficeRequest request);
        Task BookOffice(BookOfficeRequest request);
        IEnumerable<BookingDto> GetBookings(string locationName, string officeName);
        IEnumerable<LocationDto> GetLocations();
        IEnumerable<OfficeDto> GetOffices(string locationName);
        IEnumerable<OfficeDto> GetOfficeSuggestions(SuggestionsRequest request);
    }
}
