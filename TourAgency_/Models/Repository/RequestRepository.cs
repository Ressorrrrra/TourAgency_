using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Intrinsics.Arm;
using TourAgency_.Models.Entities;
using TourAgency_.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using TourAgency_.Models.DTO;

namespace TourAgency_.Models.Repository
{
    internal class RequestRepository : IRequestRepository
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


        public int GetIncome(DateTime? date1, DateTime? date2)
        {
            return db.Requests.Where(i => i.RequestStatus.Equals(RequestStatus.Accepted) && i.ConclusionDate.HasValue && i.ConclusionDate.Value.ToUniversalTime() >= date1 && i.ConclusionDate.Value.ToUniversalTime() <= date2).Sum(i => i.Price);
        }

        public int GetSoldToursAmount(DateTime? date1, DateTime? date2)
        {
            return db.Requests.Count(i => i.RequestStatus.Equals(RequestStatus.Accepted) && i.ConclusionDate.HasValue && i.ConclusionDate.Value.ToUniversalTime() >= date1 && i.ConclusionDate.Value.ToUniversalTime() <= date2);
        }

        public List<TourDto>? GetMostPopularTours(DateTime? date1, DateTime? date2, int count)
        {
            return db.Requests
        .Where(i => i.RequestStatus == RequestStatus.Accepted &&
                    i.ConclusionDate.HasValue &&
                    i.ConclusionDate.Value.ToUniversalTime() >= date1 &&
                    i.ConclusionDate.Value.ToUniversalTime() <= date2)
        .GroupBy(r => r.Tour)
        .OrderByDescending(group => group.Count())
        .Take(count)
        .Select(group => new TourDto(group.Key, group.Count() ))
        .AsEnumerable()
        .ToList();

        }


        public Request GetItem(int id)
        {
            return db.Requests.Find(id);
        }

        public List<Request> GetList()
        {
            return db.Requests.ToList();
        }

        public List<Request>? GetRequestsByEmployee(int employeeId, RequestStatus? requestStatus)
        {
            return db.Requests.Where(i => i.EmployeeId.Equals(employeeId) && (requestStatus == null || i.RequestStatus.Equals(requestStatus))).Include(r => r.Tour).ToList();
        }

        public int GetCountOfNonFreeRequest(DateTime? date1, DateTime? date2)
        {
            return db.Requests.Count(i => i.RequestStatus.Equals(RequestStatus.Sent) != true && i.ConclusionDate.HasValue && i.ConclusionDate.Value.ToUniversalTime() >= date1 && i.ConclusionDate.Value.ToUniversalTime() <= date2);
        }

        public List<Request>? GetRequestsByUser(int userId)
        {
            return db.Requests.Where(i => i.ClientId.Equals(userId)).Include(r => r.Tour).ToList();
        }

        public List<Request>? GetRequestsByUserAndStatus(int userId, RequestStatus requestStatus)
        {
            return db.Requests.Where(i => i.ClientId.Equals(userId) && i.RequestStatus.Equals(requestStatus)).Include(r => r.Tour).ToList();
        }

        public List<Request>? GetFreeRequests()
        {
            return db.Requests.Where(i => i.RequestStatus.Equals(RequestStatus.Sent)).Include(r => r.Tour).ToList();
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
