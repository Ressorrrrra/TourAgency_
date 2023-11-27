using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLevel
{
    public class Request
    {
        public int Id {  get; set; }
        public Contract Contract { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public int TourId { get; set; }
        public Tour Tour { get; set; }
        public string? Reply {  get; set; }
        public int RequestStatusId { get; set; }
        public DateTime? ConclusionDate { get; set; }
        public int Price { get; set; }
        public RequestStatus Status { get; set; }
    }
}
