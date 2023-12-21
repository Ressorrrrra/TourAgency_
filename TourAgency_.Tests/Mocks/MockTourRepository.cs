using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Moq;
using TourAgency_.Models.Entities;
using TourAgency_.Models.Interfaces;
using TourAgency_.Views.MainWindow.ChildViews.TourListView;

namespace TourAgency_.Tests.Moc
{
    public class MockTourRepository
    {
        public static List<Tour> tours = new List<Tour>()
            {
                new Tour
                {
                    Id = 1,
                    Name = "Test1",
                    Description = "Test1",
                    DirectionId = 1,
                    TransportTypeId = 1,
                    TourOperatorId = 1,
                    Price = 54000,
                    ImageLink = "dasdsadsdd"

                },
                new Tour
                {
                    Id = 2,
                    Name = "Test2",
                    Description = "Test2",
                    DirectionId = 1,
                    TransportTypeId = 2,
                    TourOperatorId = 3,
                    Price = 27000,
                }
            };
        public static Mock<ITourRepository> GetMock()
        {        
            var mock = new Mock<ITourRepository>();

            mock.Setup(m => m.GetList()).Returns(() => tours);
            mock.Setup(m => m.GetItem(It.IsAny<int>()))
                .Returns((int id) => tours.FirstOrDefault(o => o.Id == id) ?? tours[0]);
            mock.Setup(m => m.Create(It.IsAny<Tour>()))
                .Callback(() => { return; });
            mock.Setup(m => m.Update(It.IsAny<Tour>()))
               .Callback(() => { return; });
            mock.Setup(m => m.Delete(It.IsAny<int>()))
               .Callback(() => { return; });
            return mock;

        }

        
    }
}
