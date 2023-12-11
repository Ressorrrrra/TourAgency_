using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourAgency_.Models.Entities;

namespace TourAgency_.Models.DTO
{
    public class TourDto
    {
        public int Id { get; set; }
        public string? ImageLink {  get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DirectionId {  get; set; }
        //public string City { get; set; }
        //public string Country { get; set; }
        public int TransportTypeId {  get; set; }
        //public string TransportTypeName { get; set; }
        public int TourOperatorId {  get; set; }
        //public string TourOperatorName { get; set; }
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
            DirectionId = t.DirectionId;
            ImageLink = t.ImageLink;
            //City = t.Direction.City;
            //Country = t.Direction.Country;
            TransportTypeId = t.TransportTypeId;
            //TransportTypeName = t.TransportType.Name;
            TourOperatorId = t.TourOperatorId;
            //TourOperatorName = t.TourOperator.Name;
            Price = t.Price;
            HotelStarsCount = t.HotelStarsCount;
            ArrivalDate = t.ArrivalDate;
            DepartureDate = t.DepartureDate; 
        }

    }
}
