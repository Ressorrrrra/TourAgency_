using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourAgency_.Models.Interfaces;
using TourAgency_.Tests.Moc;
using UserAgency_.Tests.Mocks;

namespace TourAgency_.Tests.Mocks
{
    public static class MockUoWRepository
    {
        public static Mock<IDbRepos> GetMock()
        {
            var mock = new Mock<IDbRepos>();
            var tourRepoMock = MockTourRepository.GetMock();
            var userRepoMock = MockUserRepository.GetMock();


            mock.Setup(m => m.Tours).Returns(() => tourRepoMock.Object);
            mock.Setup(m => m.Users).Returns(() => userRepoMock.Object);

            // не тестируем запись в бд
            mock.Setup(m => m.Save()).Returns(() => { return 1; });
            return mock;
        }
    }
}
