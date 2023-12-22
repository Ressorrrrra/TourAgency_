using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourAgency_.Models.Entities;
using TourAgency_.Models.Interfaces;


namespace UserAgency_.Tests.Mocks
{
    public class MockUserRepository : IUserRepository
    {
        public static List<User> users = new List<User>()
            {
                new User
                {
                    Id = 1,
                    Login = "Login1",
                    Name = "Test1",
                    UserType = UserType.Client

                },
                new User
                {
                    Id = 2,
                    Login = "Login2",
                    Name = "Test2",
                    UserType = UserType.Administrator
                }
            };
        public static Mock<IUserRepository> GetMock()
        {
            var mock = new Mock<IUserRepository>();

            mock.Setup(m => m.GetList()).Returns(() => users);
            mock.Setup(m => m.GetItem(It.IsAny<int>()))
                .Returns((int id) => users.FirstOrDefault(o => o.Id == id) ?? users[0]);
            mock.Setup(m => m.Create(It.IsAny<User>()))
                .Callback(() => { return; });
            mock.Setup(m => m.Update(It.IsAny<User>()))
               .Callback(() => { return; });
            mock.Setup(m => m.Delete(It.IsAny<int>()))
               .Callback(() => { return; });
            return mock;

        }

        public void Create(User item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetList()
        {
            throw new NotImplementedException();
        }

        public List<User>? GetListByUserType(UserType userType)
        {
            throw new NotImplementedException();
        }

        public User? GetUser(string login, string password)
        {
            throw new NotImplementedException();
        }

        public User? GetUserByLogin(string login)
        {
            throw new NotImplementedException();
        }

        public void Update(User item)
        {
            throw new NotImplementedException();
        }
    }
}
