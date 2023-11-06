
using DomainLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.DTO
{
    public class ContractDto
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int TourId { get; set; }
        public string TourName { get; set; }
        public DateOnly ConclusionDate { get; set; }
        public int TotalCost { get; set; }

        public ContractDto(Contract c)
        {
                Id = c.Id;
            ClientId = c.Client.Id;
            ClientName = c.Client.Name;
            EmployeeId = c.Employee.Id;
            EmployeeName = c.Employee.Name;
            TourId = c.Tour.Id;
            TourName = c.Tour.Name;
            ConclusionDate = c.ConclusionDate;
            TotalCost = c.TotalCost;
        }

        public ContractDto(int clientId, int tourId, int employeeId, string clientName, string employeeName, string tourName, int totalCost, DateOnly conclusionDate)
        {
            ClientId = clientId;
            ClientName = clientName;
            EmployeeId = employeeId;
            EmployeeName = employeeName;
            TourId = tourId;
            TourName = tourName;
            ConclusionDate = conclusionDate;
            TotalCost = totalCost;
        }
        public ContractDto()
        {
                
        }

    }
}
