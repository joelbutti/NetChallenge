using Moq;
using NetChallenge.Application.Common.Interfaces;
using NetChallenge.Domain.Abstractions;
using NetChallenge.Infrastructure.Persistence.Repositories;
using NetChallenge.Infrastructure.Services;

namespace NetChallenge.Test
{
    public class OfficeRentalServiceTest
    {
        protected OfficeRentalService Service;
        protected ILocationRepository LocationRepository;
        protected IOfficeRepository OfficeRepository;
        protected IBookingRepository BookingRepository;

        public OfficeRentalServiceTest()
        {
            var dbContext = new Mock<IApplicationDbContext>();

            LocationRepository = new LocationRepository(dbContext.Object);
            OfficeRepository = new OfficeRepository(dbContext.Object);
            BookingRepository = new BookingRepository(dbContext.Object);
            Service = new OfficeRentalService(LocationRepository, OfficeRepository, BookingRepository);
        }
    }
}