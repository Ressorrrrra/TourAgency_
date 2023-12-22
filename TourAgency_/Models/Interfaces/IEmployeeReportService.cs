using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourAgency_.Models.Interfaces
{
    public interface IEmployeeReportService
    {
        int EmployeePerfomanceByDate(DateTime date, int employeeId);
    }
}
