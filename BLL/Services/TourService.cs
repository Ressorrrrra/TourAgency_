using DomainLevel;
using Interfaces.DTO;
using Interfaces.Repository;
using Interfaces.Services;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BLL.Services
{
    public class TourService : ITourService
    {
        private IDbRepos db;

        public TourService(IDbRepos repos)
        {
            db = repos;
        }
        public void CreateTour(TourDto t)
        {
            db.Tours.Create(new Tour()
            {
                Name = t.Name,
                Description = t.Description,
                ArrivalDate = t.ArrivalDate,
                DepartureDate = t.DepartureDate,
                HotelStarsCount = t.HotelStarsCount,
                Price = t.Price,
                Direction = new Direction() { City = t.Direction.City, Country = t.Direction.Country },
                TransportType = new TransportType() { Name = t.TransportType.Name },
                TourOperator = new TourOperator() { Name = t.TourOperator.Name }
            });
        }

        public void DeleteTour(int id)
        {
            Tour p = db.Tours.GetItem(id);
            if (p != null)
            {
                db.Tours.Delete(p.Id);
                db.Save();
            }
        }

        public List<TourDto> GetAllTours()
        {
            return db.Tours.GetList().Select(i => new TourDto(i)).ToList();
        }

        public TourDto GetTour(int id)
        {
            return new TourDto(db.Tours.GetItem(id));
        }

        public void UpdateTour(TourDto tour)
        {
            Tour t = db.Tours.GetItem(tour.Id);
            t.Name = t.Name;
            t.Description = t.Description;
            t.ArrivalDate = t.ArrivalDate;
            t.DepartureDate = t.DepartureDate;
            t.HotelStarsCount = t.HotelStarsCount;
            t.Price = t.Price;
            t.Direction = new Direction() { City = t.Direction.City, Country = t.Direction.Country };
            t.TransportType = new TransportType() { Name = t.TransportType.Name };
            t.TourOperator = new TourOperator() { Name = t.TourOperator.Name };
            db.Tours.Update(t);
            Save(db);
        }

        public bool Save(IDbRepos db)
        {
            if (db.Save() > 0) return true;
            return false;
        }
    }
}
