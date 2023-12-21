using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourAgency_.Models.Entities;
using TourAgency_.Models.Interfaces;
using TourAgency_.Views.MainWindow.ChildViews.TourListView;

namespace TourAgency_.Models.Repository.Mocks
{
    public class TourMockRepository  
    {
        public static List<Tour> Tours => new List<Tour>()
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

        public TourMockRepository()
        {
            //var mock = Moc
        }

        public void Create(Tour item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Tour GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public List<Tour> GetList()
        {
            throw new NotImplementedException();
        }

        public void Update(Tour item)
        {
            throw new NotImplementedException();
        }
    }
}
