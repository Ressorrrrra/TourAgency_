
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourAgency_.Models.Entities;

namespace TourAgency_.Models.DTO
{
    public class RequestDto
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int? EmployeeId { get; set; }
        public int TourId { get; set; }
        public string TourName { get; set; }
        public string? Reply { get; set; }
        public int RequestStatusId { get; set; }
        public DateTime? ConclusionDate { get; set; }
        public int Price { get; set; }

        public RequestDto()
        {
                
        }
    }
}
