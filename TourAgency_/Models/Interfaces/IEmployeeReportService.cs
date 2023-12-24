using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourAgency_.Models.DTO;

namespace TourAgency_.Models.Interfaces
{
    public interface IEmployeeReportService
    {
        public int EmployeePerfomanceByDate(DateTime date, int employeeId);
        public List<UserDto>? GetMostEfficientEmployees(DateTime? date1, DateTime? date2, int count);
    }
}
