using DomainLevel;
using Interfaces.DTO;
using Interfaces.Repository;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private IDbRepos db;
        private ILoggingService logging;
        public UserService(IDbRepos repos, ILoggingService loggingService)
        {
            db = repos;
            this.logging = loggingService;
        }

        public UserDto? GetUser(string login, string password)
        {
            var user = logging.FindUser(login, password);
            if (user != null)
            {
                return new UserDto(logging.FindUser(login, password));
            }
            else return null;

        }

        public bool Save(IDbRepos db)
        {
            if (db.Save() > 0) return true;
            return false;
        }
        public void CreateUser(UserDto User)
        {
            db.Users.Create(new User()
            {
                Name = User.Name,
                Login = User.Login,
                Password = User.Password,
                DateOfBirth = User.DateOfBirth,
                PassportNumber = User.PassportNumber,
                InternationalPassportNumber = User.InternationalPassportNumber
            });
            Save(db);
        }

        public void DeleteUser(int id)
        {
            User p = db.Users.GetItem(id);
            if (p != null)
            {
                db.Users.Delete(p.Id);
                Save(db);
            }
        }

        public List<UserDto> GetAllUsers()
        {
            return db.Users.GetList().Select(i => new UserDto(i)).ToList();
        }

        public UserDto GetUser(int id)
        {
            return new UserDto(db.Users.GetItem(id));
        }



        public void UpdateUser(UserDto User)
        {
            User u = db.Users.GetItem(User.Id);
            u.Name = User.Name;
            u.Login = User.Login;
            u.Password = User.Password;
            u.UserType = User.UserType;
            u.DateOfBirth = User.DateOfBirth;
            u.PassportNumber = User.PassportNumber;
            u.InternationalPassportNumber = User.InternationalPassportNumber;
            db.Users.Update(u);
            Save(db);
        }
    }
}
