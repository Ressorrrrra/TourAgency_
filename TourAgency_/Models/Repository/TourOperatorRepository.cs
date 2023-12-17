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
    public class TourOperatorRepository : ITourOperatorRepository
    {
        private TourAgencyContext db;

        public TourOperatorRepository(TourAgencyContext context)
        {
            db = context;
        }
        public void Create(TourOperator item)
        {
            db.TourOperators.Add(item);
            Save(db);
        }

        public void Delete(int id)
        {
            TourOperator TourOperator = GetItem(id);
            if (TourOperator != null)
            {
                db.TourOperators.Remove(TourOperator);
                Save(db);
            }
        }

        public TourOperator GetItem(int id)
        {
            return db.TourOperators.Find(id);
        }

        public List<TourOperator> GetList()
        {
            return db.TourOperators.ToList();
        }

        public void Update(TourOperator item)
        {
            db.TourOperators.Update(item);
            Save(db);
        }

        void Save(TourAgencyContext db)
        {
            db.SaveChanges();
        }
    }
}
