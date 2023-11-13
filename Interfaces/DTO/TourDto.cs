using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLevel;

namespace Interfaces.DTO
{
    public class TourDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DirectionDto Direction {  get; set; }
        public TransportTypeDto TransportType {  get; set; }
        public TourOperatorDto TourOperator {  get; set; }
        public int Price { get; set; }
        public int HotelStarsCount { get; set; }
        public DateOnly ArrivalDate { get; set; }
        public DateOnly DepartureDate {  get; set; }
        public TourDto()
        {
                
        }

        public TourDto(Tour t)
        {
            Id = t.Id;
            Name = t.Name;
            Description = t.Description;
            Direction = new DirectionDto(t.Direction);
            TransportType = new TransportTypeDto(t.TransportType);
            TourOperator = new TourOperatorDto(t.TourOperator);
            Price = t.Price;
            HotelStarsCount = t.HotelStarsCount;
            ArrivalDate = t.ArrivalDate;
            DepartureDate = t.DepartureDate; 
        }

    }
}
