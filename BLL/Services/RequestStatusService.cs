using DAL;
using DomainLevel;
using Interfaces.DTO;
using Interfaces.Repository;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class RequestStatusService : IRequestStatusService
    {

        private IDbRepos db;

        public RequestStatusService(IDbRepos repos)
        {
            db = repos;
        }

        public List<RequestStatusDto> GetAllRequestStatuses()
        {
            return db.RequestStatuses.GetList().Select(i => new RequestStatusDto(i)).ToList();
        }


        public RequestStatusDto GetRequestStatus(int Id)
        {
            return new RequestStatusDto(db.RequestStatuses.GetItem(Id));
        }

        public void CreateRequestStatus(RequestStatusDto t)
        {
            db.RequestStatuses.Create(new RequestStatus() { Status = t.Status });
            db.Save();

        }



        public void UpdateRequestStatus(RequestStatusDto rt)
        {
            RequestStatus r = db.RequestStatuses.GetItem(rt.Id);
            r.Status = rt.Status;
            db.RequestStatuses.Update(r);
            db.Save();
        }

        public void DeleteRequestStatus(int id)
        {
            RequestStatus t = db.RequestStatuses.GetItem(id);
            if (t != null)
            {
                db.RequestStatuses.Delete(t.Id);
                db.Save();
            }
        }

        public bool Save(TourAgencyContext db)
        {
            if (db.SaveChanges() > 0) return true;
            return false;
        }
    }
}
