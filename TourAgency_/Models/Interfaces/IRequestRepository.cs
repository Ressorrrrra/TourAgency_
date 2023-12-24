
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourAgency_.Models.DTO;
using TourAgency_.Models.Entities;

namespace TourAgency_.Models.Interfaces
{
    public interface IRequestRepository : IRepository<Request>
    {
        public List<Request>? GetRequestsByUser(int userId);
        public List<Request>? GetRequestsByUserAndStatus(int userId, RequestStatus requestStatus);
        public List<Request>? GetFreeRequests();
        public List<Request>? GetRequestsByEmployee(int employeeId, RequestStatus? requestStatus);
        public int GetIncome(DateTime? date1, DateTime? date2);
        public int GetSoldToursAmount(DateTime? date1, DateTime? date2);
        public List<TourDto>? GetMostPopularTours(DateTime? date1, DateTime? date2, int count);
        public int GetCountOfNonFreeRequest(DateTime? date1, DateTime? date2);
    }
}
