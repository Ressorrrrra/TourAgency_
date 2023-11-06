using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IEmployeeService
    {
        List<EmployeeDto> GetAllEmployees();
        EmployeeDto GetEmployee(int id);

        void CreateEmployee(EmployeeDto employee);

        void UpdateEmployee(EmployeeDto employee);

        void DeleteEmployee(int id);
    }
}
