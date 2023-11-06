using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
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
