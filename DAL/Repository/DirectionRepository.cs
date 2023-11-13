using DomainLevel;
using Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class DirectionRepository : IRepository<Direction>
    {
        private TourAgencyContext db;

        public DirectionRepository(TourAgencyContext context)
        {
            db = context;
        }
        public void Create(Direction item)
        {
            db.Directions.Add(item);
        }

        public void Delete(int id)
        {
            Direction Direction = GetItem(id);
            if (Direction != null)
            {
                db.Directions.Remove(Direction);
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
        }
    }
}
