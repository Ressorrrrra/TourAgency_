using System;

namespace TourAgency_.Models.Entities
{
    public class Contract
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public Employee Employee { get; set; }
        public Tour Tour { get; set; }
        public DateOnly ConclusionDate { get; set; }
        public int TotalCost { get; set; }
    }

}
