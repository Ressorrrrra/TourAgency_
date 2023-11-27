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
                DirectionId = t.DirectionId,
                Direction = db.Directions.GetItem(t.DirectionId),
                TransportTypeId = t.TransportTypeId,
                TransportType = db.TransportTypes.GetItem(t.TransportTypeId),
                TourOperatorId = t.TourOperatorId,
                TourOperator = db.TourOperators.GetItem(t.TourOperatorId),
            });
            db.Save();
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
            t.Name = tour.Name;
            t.Description = tour.Description;
            t.ArrivalDate = tour.ArrivalDate;
            t.DepartureDate = tour.DepartureDate;
            t.HotelStarsCount = tour.HotelStarsCount;
            t.Price = tour.Price;
            t.DirectionId = tour.DirectionId;
            t.Direction = db.Directions.GetItem(tour.DirectionId);
            t.TransportTypeId = tour.TransportTypeId;
            t.TransportType = db.TransportTypes.GetItem(tour.TransportTypeId);
            t.TourOperatorId = tour.TourOperatorId;
            t.TourOperator = db.TourOperators.GetItem(tour.TourOperatorId);
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
