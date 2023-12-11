using System;

namespace TourAgency_.Models.Entities
{
    public class Tour
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DirectionId { get; set; }
        public Direction Direction { get; set; }
        public int TransportTypeId { get; set; }
        public TransportType TransportType { get; set; }
        public int TourOperatorId { get; set; }
        public TourOperator TourOperator { get; set; }
        public DateOnly ArrivalDate { get; set; }
        public DateOnly DepartureDate { get; set; }
        public int HotelStarsCount { get; set; }
        public string? ImageLink { get; set; }
        public int Price { get; set; }
    }
}
