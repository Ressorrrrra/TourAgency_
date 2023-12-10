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
    public class RequestService : IRequestService
    {
        private IDbRepos db;

        public RequestService(IDbRepos repos)
        {
            db = repos;
        }
        public void CreateRequest(RequestDto t)
        {
            db.Requests.Create(new Request()
            {
                Client = db.Users.GetItem(t.ClientId),
                ClientId = t.ClientId,
                Tour = db.Tours.GetItem(t.TourId),
                TourId = t.TourId,
                RequestStatusId = t.RequestStatusId,
                RequestStatus = db.RequestStatuses.GetItem(t.RequestStatusId),
                Price = t.Price,
            }) ;
            db.Save();
        }

        public void DeleteRequest(int id)
        {
            Request p = db.Requests.GetItem(id);
            if (p != null)
            {
                db.Requests.Delete(p.Id);
                db.Save();
            }
        }

        public List<RequestDto> GetAllRequests()
        {
            return db.Requests.GetList().Select(i => new RequestDto(i)).ToList();
        }

        public RequestDto GetRequest(int id)
        {
            return new RequestDto(db.Requests.GetItem(id));
        }

        public void UpdateRequest(RequestDto request)
        {
            Request r = db.Requests.GetItem(request.Id);
            r.Client = db.Users.GetItem(request.ClientId);
            r.ClientId = request.ClientId;
            if (request.EmployeeId != null)
            {
                r.EmployeeId = request.EmployeeId;
                r.Employee = db.Users.GetItem(request.EmployeeId.Value);
            }
            r.TourId = request.TourId;
            r.Tour = db.Tours.GetItem(request.TourId);
            if (request.ConclusionDate != null) r.ConclusionDate = r.ConclusionDate.Value;
            r.RequestStatusId = request.RequestStatusId;
            r.RequestStatus = db.RequestStatuses.GetItem(request.RequestStatusId);
            r.Reply = request.Reply;
            r.Price = request.Price;

            db.Requests.Update(r);
            Save(db);
        }

        public bool Save(IDbRepos db)
        {
            if (db.Save() > 0) return true;
            return false;
        }
    }
}
