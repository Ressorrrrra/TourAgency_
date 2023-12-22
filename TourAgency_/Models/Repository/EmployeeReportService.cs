using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourAgency_.Models.Entities;
using TourAgency_.Models.Interfaces;

namespace TourAgency_.Models.Repository
{
    public class EmployeeReportService : IEmployeeReportService
    {
        private TourAgencyContext db;

        public EmployeeReportService(TourAgencyContext context)
        {
            db = context;
        }

        public int EmployeePerfomanceByDate(DateTime date, int employeeId)
        {
            DateTime now = DateTime.Now.ToUniversalTime();
            DateTime utcDate = date.ToUniversalTime();

            return db.Requests.Count(i => i.EmployeeId.Equals(employeeId) && !i.RequestStatus.Equals(RequestStatus.Sent) && i.ConclusionDate.HasValue  && i.ConclusionDate.Value.ToUniversalTime()>=utcDate && i.ConclusionDate.Value.ToUniversalTime()<now);
        }
    }
}
