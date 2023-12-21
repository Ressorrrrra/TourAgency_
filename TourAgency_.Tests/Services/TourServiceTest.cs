using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TourAgency_.Models.Entities;
using TourAgency_.Models.Interfaces;
using TourAgency_.Models.Repository;
using TourAgency_.Tests.Moc;
using TourAgency_.Tests.Mocks;
using UserAgency_.Tests.Mocks;

namespace TourAgency_.Tests.Services
{
    public class TourServiceTest
    {
        Mock<IDbRepos> uowMock;
        Mock<TourAgencyContext> contextMock;
        TourRepository tourRepository;

        private readonly Tour _NoTour = new Tour
        {

        };
        private readonly Tour _InvalidTour = new Tour
        {
            Description = "description",
        };
        private readonly Tour _ValidTour = new Tour
        {
            Id = 1,
            Name = "tour name",
            Description = "description",
            DirectionId = 1,
            TransportTypeId = 2,
            TourOperatorId = 1,
            ArrivalDate = DateOnly.Parse("01.01.2020"),
            DepartureDate = DateOnly.Parse("08.08.2020"),
            Price = 1200,
            HotelStarsCount = 4

        };


        [SetUp]
        public void Setup()
        {
            uowMock = MockUoWRepository.GetMock();
            var data = new List<Tour>
            {
            new Tour { Id = 1, Name = "Entity 1" },
            new Tour { Id = 2, Name = "Entity 2" },
        }.AsQueryable();

            var mockSet = new Mock<DbSet<Tour>>();
            mockSet.As<IQueryable<Tour>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Tour>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Tour>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Tour>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<TourAgencyContext>();
            mockContext.Setup(c => c.Set<Tour>()).Returns(mockSet.Object);
            tourRepository = new TourRepository(mockContext.Object);
        }

        //[Test]
        //public void CreateOrder_Fail()
        //{
        //    //var result = service.MakeOrder(_NoPhoneTour);
        //    try
        //    {
        //        //Assert.Throws<ArgumentNullException>(() => tourRepository.Create(null));
        //        //Assert.Throws<TargetInvocationException>(() => tourRepository.Create(_InvalidTour));
        //    }
        //    catch (Exception ex) { }

        //    Assert.Pass();
        //}

        //[Test]
        //public void CreateOrder_Success()
        //{

        //    var result = tourRepository.Create(_ValidTour);
        //    Assert.IsNotNull(result);
        //    Assert.GreaterOrEqual(1, result.Id);
        //    string ph1stName = uowMock.Object.Phones.GetItem(_ValidOnePhoneTour.OrderedPhonesIds[0]).Name ?? "";
        //    Assert.That(result.OrderedPhones, Is.EqualTo(ph1stName));

        //    Assert.Pass();
        //}

        //[Test]
        //public void CreateOrderOfPhonesArray_Success()
        //{
        //    var ph1 = uowMock.Object.Phones.GetItem(_ValidManyPhonesTour.OrderedPhonesIds[0]);
        //    var ph2 = uowMock.Object.Phones.GetItem(_ValidManyPhonesTour.OrderedPhonesIds[1]);

        //    var result = service.MakeOrder(_ValidManyPhonesTour);
        //    Assert.IsNotNull(result);
        //    Assert.GreaterOrEqual(1, result.Id);

        //    string ph1stName = ph1.Name ?? "";
        //    string ph2ndName = ph2.Name ?? "";
        //    StringAssert.Contains(ph1stName, result.OrderedPhones);
        //    StringAssert.Contains(ph2ndName, result.OrderedPhones);

        //    Assert.Pass();
        //}
    }
}
