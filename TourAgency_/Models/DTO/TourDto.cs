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
        public Tour Tour { get; set; }
        public int SoldAmount { get; set; }

        public TourDto(Tour t, int soldAmount)
        {
            Tour = t;
            SoldAmount = soldAmount;
        }

    }
}
