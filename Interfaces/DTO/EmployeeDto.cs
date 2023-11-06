
using DomainLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.DTO
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int ContractCount { get; set; }

        public EmployeeDto(Employee c)
        {
            Id = c.Id;
            Name = c.Name;
            ContractCount = c.ContractCount;
        }

        public EmployeeDto()
        {
                
        }

        public override string ToString() => $"{Name}";
    }
}
