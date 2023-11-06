using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? PassportNumber { get; set; }

        public int? InternationalPassportNumber { get; set; }
        public string TourCount { get; set; }

    }

}
