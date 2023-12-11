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
    public class RequestStatusRepository : IRepository<RequestStatus>
    {
        private TourAgencyContext db;

        public RequestStatusRepository(TourAgencyContext context)
        {
            db = context;
        }
        public void Create(RequestStatus item)
        {
            db.RequestStatuses.Add(item);
        }

        public void Delete(int id)
        {
            RequestStatus RequestStatus = GetItem(id);
            if (RequestStatus != null)
            {
                db.RequestStatuses.Remove(RequestStatus);
            }
        }

        public RequestStatus GetItem(int id)
        {
            return db.RequestStatuses.Find(id);
        }

        public List<RequestStatus> GetList()
        {
            return db.RequestStatuses.ToList();
        }

        public void Update(RequestStatus item)
        {
            db.RequestStatuses.Update(item);
        }
    }
}
