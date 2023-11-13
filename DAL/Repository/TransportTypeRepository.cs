using DomainLevel;
using Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class TransportTypeRepository : IRepository<TransportType>
    {
        private TourAgencyContext db;

        public TransportTypeRepository(TourAgencyContext context)
        {
            db = context;
        }
        public void Create(TransportType item)
        {
            db.TransportTypes.Add(item);
        }

        public void Delete(int id)
        {
            TransportType TransportType = GetItem(id);
            if (TransportType != null)
            {
                db.TransportTypes.Remove(TransportType);
            }
        }

        public TransportType GetItem(int id)
        {
            return db.TransportTypes.Find(id);
        }

        public List<TransportType> GetList()
        {
            return db.TransportTypes.ToList();
        }

        public void Update(TransportType item)
        {
            db.TransportTypes.Update(item);
        }
    }
}
