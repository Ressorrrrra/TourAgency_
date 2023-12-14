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
    internal class RequestRepository : IRepository<Request>
    {
        private TourAgencyContext db;

        public RequestRepository(TourAgencyContext context)
        {
            db = context;
        }
        public void Create(Request item)
        {
            db.Requests.Add(item);
            Save(db);
        }

        public void Delete(int id)
        {
            Request Request = GetItem(id);
            if (Request != null)
            {
                db.Requests.Remove(Request);
                Save(db);
            }
        }

        public Request GetItem(int id)
        {
            return db.Requests.Find(id);
        }

        public List<Request> GetList()
        {
            return db.Requests.ToList();
        }

        public void Update(Request item)
        {
            db.Requests.Update(item);
            Save(db);
        }

        void Save(TourAgencyContext db)
        {
            db.SaveChanges();
        }
    }
}
