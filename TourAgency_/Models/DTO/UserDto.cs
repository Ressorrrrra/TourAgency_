
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourAgency_.Models.Entities;

namespace TourAgency_.Models.DTO
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public UserType UserType { get; set; }
        public string? Name { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string? PassportNumber { get; set; }
        public string? InternationalPassportNumber { get; set; }

        public UserDto()
        {
            Id = 0;
            Login = "";
            Password = "";
            UserType = UserType.Client;
        }

        public UserDto(User u)
        {
                Id = u.Id;
            Login = u.Login;
            Password = u.Password;
            UserType = u.UserType;
            Name = u.Name;
            DateOfBirth = u.DateOfBirth;
            PassportNumber = u.PassportNumber;
            InternationalPassportNumber = u.InternationalPassportNumber;

        }
    }
}
