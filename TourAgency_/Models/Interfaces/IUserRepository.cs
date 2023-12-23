
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourAgency_.Models.Entities;

namespace TourAgency_.Models.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {

        User? GetUser(string login, string password);

        User? GetUserByLogin(string login);

        List<User>? GetListByUserType(UserType userType);
        List<User>? GetListByUserNameAndType(string name);

    }
}
