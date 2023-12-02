using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLevel
{
    public class UserData
    {
        public User User { get; set; }
        public string? Name { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string? PassportNumber { get; set; }
        public string? InternationalPassportNumber { get; set; }
    }
}
