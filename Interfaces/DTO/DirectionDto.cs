using DomainLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.DTO
{
    public class DirectionDto
    {
        public int Id {  get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public DirectionDto()
        {
                
        }

        public DirectionDto(Direction d)
        {
            Id = d.Id;
            City = d.City;
            Country = d.Country;
        }
    }
}
