using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourAgency_.Models.DTO;
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
        public List<UserDto>? GetMostEfficientEmployees(DateTime? date1, DateTime? date2, int count)
        {
            return db.Requests
    .Where(i => i.EmployeeId.HasValue && i.ConclusionDate.HasValue && i.ConclusionDate.Value.ToUniversalTime() >= date1 && i.ConclusionDate.Value.ToUniversalTime() <= date2) // Filter out requests without an employee ID
    .GroupBy(i => i.Employee)
    .OrderByDescending(group => group.Count())
    .Take(5) // Change the number to the desired top N employees
    .Select(group => new UserDto(group.Key, group.Count()))
    .ToList();
        }
    }
}
