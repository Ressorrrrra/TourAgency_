using DomainLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.DTO
{
    public class RequestDto
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int? EmployeeId { get; set; }
        public int TourId { get; set; }
        public string? Reply { get; set; }
        public int RequestStatusId { get; set; }
        public DateTime? ConclusionDate { get; set; }
        public int Price { get; set; }

        public RequestDto(Request r)
        {
            Id = r.Id;
            ClientId = r.ClientId;  
            EmployeeId = r.EmployeeId;
            TourId = r.TourId;
            Reply = r.Reply;
            RequestStatusId = r.RequestStatusId;
            ConclusionDate = r.ConclusionDate;
            Price = r.Price;    
        }

        public RequestDto()
        {
                
        }
    }
}
