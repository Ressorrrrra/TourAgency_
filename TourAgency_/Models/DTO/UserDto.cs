
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
        public User User {  get; set; }
        public int Count {  get; set; }

        public UserDto(User u, int count)
        {
            User = u;
            Count = count;

        }
    }
}
