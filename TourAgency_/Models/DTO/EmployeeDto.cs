
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourAgency_.Models.Entities;

namespace TourAgency_.Models.DTO
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }
        public int ContractCount { get; set; }

        public EmployeeDto(Employee c)
        {
            Id = c.Id;
            Login = c.Login;
            Password = c.Password;
            Name = c.Name;
            ContractCount = c.ContractCount;
        }

        public EmployeeDto()
        {
                
        }

        public override string ToString() => $"{Name}";
    }
}
