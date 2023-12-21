using TourAgency_.Models.Repository;
using TourAgency_.Models.Entities;
using TourAgency_.Models.Interfaces;
using TourAgency_.Models.Repository.Mocks;

namespace TourAgency_.Tests
{
    public class Tests
    {
        [SetUp]

        //Mock<ITourRepository> tourRepository;
        public void Setup()
        {

            //tourRepository = new TourMockRepository();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}