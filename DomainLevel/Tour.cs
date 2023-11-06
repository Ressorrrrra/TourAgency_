using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLevel
{
    public class Tour
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Direction Direction { get; set; }
        public TransportType TransportType { get; set; }
        public TourOperator TourOperator { get; set; }
        public DateOnly ArrivalDate { get; set; }
        public DateOnly DepartureDate { get; set; }
        public int HotelStarsCount { get; set; }
        public int Price { get; set; }
    }
}
