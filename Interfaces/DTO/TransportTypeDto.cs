using DomainLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.DTO
{
    public class TransportTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public TransportTypeDto()
        {

        }

        public TransportTypeDto(TransportType t)
        {
            Id = t.Id;
            Name = t.Name;
        }
    }
}
