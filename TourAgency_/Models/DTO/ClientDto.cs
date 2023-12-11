using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourAgency_.Models.Entities;

namespace TourAgency_.Models.DTO
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string? PassportNumber { get; set; }

        public string? InternationalPassportNumber { get; set; }
        public ClientDto(Client c)
        {
            this.Id = c.Id;    
            this.Login = c.Login;
            this.Password = c.Password;
            this.Name = c.Name;
            this.DateOfBirth = c.DateOfBirth;
            this.PassportNumber = c.PassportNumber;
            this.InternationalPassportNumber = c.InternationalPassportNumber;
        }
        public ClientDto()
        {
                
        }
    }
}
