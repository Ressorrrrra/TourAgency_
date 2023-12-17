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
    public class DirectionRepository : IDirectionRepository
    {
        private TourAgencyContext db;

        public DirectionRepository(TourAgencyContext context)
        {
            db = context;
        }
        public void Create(Direction item)
        {
            db.Directions.Add(item);
            Save(db);
        }

        public void Delete(int id)
        {
            Direction Direction = GetItem(id);
            if (Direction != null)
            {
                db.Directions.Remove(Direction);
                Save(db);
            }
        }

        public Direction GetItem(int id)
        {
            return db.Directions.Find(id);
        }

        public List<Direction> GetList()
        {
            return db.Directions.ToList();
        }

        public void Update(Direction item)
        {
            db.Directions.Update(item);
            Save(db);
        }

        void Save(TourAgencyContext db)
        {
            db.SaveChanges();
        }
    }
}
