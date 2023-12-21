using Moq;
using Ninject.Activation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourAgency_.Models.Entities;
using TourAgency_.Models.Interfaces;
using TourAgency_.Models.Repository;
using UserAgency_.Tests.Mocks;

namespace TourAgency_.Tests.Services
{
    public class UserTest
    {
        Mock<IUserRepository> userRepository = new Mock<IUserRepository>();

        private User[] users =
        {
            new User {Id = 1, Login = "User1", Password = "123"},
            new User {Id = 2, Login = "User2", Password = "456"}
        };


        [Test]
        public void UserGetUserByLogin_Null()
        {
            userRepository.Setup(m => m.GetUserByLogin("")).Returns((string username) => users.FirstOrDefault(u => u.Login == username));

            var result = userRepository.Object.GetUserByLogin("");

            Assert.IsNull(result);
        }
        [Test]
        public void UserGetUserByLogin_Success()
        {
            userRepository.Setup(m => m.GetUserByLogin(users[1].Login)).Returns((string username) => users.FirstOrDefault(u => u.Login == username));

            var result = userRepository.Object.GetUserByLogin(users[1].Login);

            Assert.AreEqual(users[1], result);
        }

        [Test]
        public void Authorization_Fail()
        {
            userRepository.Setup(m => m.GetUser("wrong login", "wrong password")).Returns((string username, string password) => users.FirstOrDefault(u => u.Login.Equals(username) && u.Password.Equals(password)));


            var result = userRepository.Object.GetUser("wrong login", "wrong password");

            Assert.IsNull(result);

            userRepository.Setup(m => m.GetUser("User1", "wrong password")).Returns((string username, string password) => users.FirstOrDefault(u => u.Login.Equals(username) && u.Password.Equals(password)));

            result = userRepository.Object.GetUser("User1", "wrong password");

            Assert.IsNull(result);

            userRepository.Setup(m => m.GetUser("wrong login", "123")).Returns((string username, string password) => users.FirstOrDefault(u => u.Login.Equals(username) && u.Password.Equals(password)));

            result = userRepository.Object.GetUser("wrong login", "123");

            Assert.IsNull(result);


        }

        [Test]
        public void Authorization_Success() 
        {
            userRepository.Setup(m => m.GetUser(users[1].Login, users[1].Password)).Returns((string username, string password) => users.FirstOrDefault(u => u.Login.Equals(username) && u.Password.Equals(password)));

            var result = userRepository.Object.GetUser(users[1].Login, users[1].Password);

            Assert.AreEqual(users[1], result);
        }

    }
}
