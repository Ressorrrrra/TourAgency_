using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IUserService
    {
        List<UserDto> GetAllUsers();
        UserDto GetUser(int id);
        UserDto? GetUser(string login, string password);

        void CreateUser(UserDto User);

        void UpdateUser(UserDto User);

        void DeleteUser(int id);

    }
}
