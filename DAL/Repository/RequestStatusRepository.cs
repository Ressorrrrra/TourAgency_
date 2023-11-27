using DomainLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class RequestStatusRepository
    {
        private TourAgencyContext db;

        public RequestStatusRepository(TourAgencyContext context)
        {
            db = context;
        }
        public void Create(RequestStatus item)
        {
            db.RequestStatuss.Add(item);
        }

        public void Delete(int id)
        {
            RequestStatus RequestStatus = GetItem(id);
            if (RequestStatus != null)
            {
                db.RequestStatuss.Remove(RequestStatus);
            }
        }

        public RequestStatus GetItem(int id)
        {
            return db.RequestStatuss.Find(id);
        }

        public List<RequestStatus> GetList()
        {
            return db.RequestStatuss.ToList();
        }

        public void Update(RequestStatus item)
        {
            db.RequestStatuss.Update(item);
        }
    }
}
