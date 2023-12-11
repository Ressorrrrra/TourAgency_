using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourAgency_.Models.Entities;

namespace TourAgency_.Models.DTO
{
    public class TourOperatorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public TourOperatorDto()
        {
                
        }

        public TourOperatorDto(TourOperator t)
        {
            Id = t.Id;
            Name = t.Name;
        }
    }
}
