using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Intrinsics.Arm;
using TourAgency_.Models.Entities;
using TourAgency_.Models.Interfaces;

namespace TourAgency_.Models.Repository
{
    public class TourRepository : IRepository<Tour>
    {
        private TourAgencyContext db;

        public TourRepository(TourAgencyContext context)
        {
            db = context;
        }
        public void Create(Tour item)
        {
            db.Tours.Add(item);
        }

        public void Delete(int id)
        {
            Tour tour = GetItem(id);
            if (tour != null)
            {
                db.Tours.Remove(tour);
            }
        }

        public Tour GetItem(int id)
        {
            return db.Tours.Find(id);
        }

        public List<Tour> GetList()
        {
            return db.Tours.ToList();
        }

        public void Update(Tour item)
        {
            db.Tours.Update(item);
        }
    }
}
