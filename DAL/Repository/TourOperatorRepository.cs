using DomainLevel;
using Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class TourOperatorRepository : IRepository<TourOperator>
    {
        private TourAgencyContext db;

        public TourOperatorRepository(TourAgencyContext context)
        {
            db = context;
        }
        public void Create(TourOperator item)
        {
            db.TourOperators.Add(item);
        }

        public void Delete(int id)
        {
            TourOperator TourOperator = GetItem(id);
            if (TourOperator != null)
            {
                db.TourOperators.Remove(TourOperator);
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
        }
    }
}
