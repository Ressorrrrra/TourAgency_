
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourAgency_.Models.Entities;
using TourAgency_.Models.Interfaces;

namespace TourAgency_.Models.Repository
{
    public class UserRepository : IRepository<User>, IUserRepository
    {
        private TourAgencyContext db;

        public UserRepository(TourAgencyContext context)
        {
            db = context;
        }

        public User? GetUser(string login, string password)
        {
            return db.Users.FirstOrDefault(g => g.Login.Equals(login) && g.Password.Equals(password));
        }

        public User? GetUserByLogin(string login)
        {
            return db.Users.FirstOrDefault(g => g.Login.Equals(login));
        }

        public void Create(User item)
        {
            db.Users.Add(item);
            this.Save(db);
        }

        public void Delete(int id)
        {
            User User = GetItem(id);
            if (User != null)
            {
                db.Users.Remove(User);
                Save(db);
            }
        }

        public User? GetItem(int id)
        {
            return db.Users.Find(id);
        }

        public List<User> GetList()
        {
           return db.Users.ToList();
        }


        public void Update(User item)
        {
            db.Users.Update(item);
            Save(db);
        }

        void Save(TourAgencyContext db)
        {
            db.SaveChanges();
        }

        public List<User>? GetListByUserType(UserType userType)
        {
            return db.Users.Where(i=> i.UserType.Equals(userType)).ToList();
        }


    }
}
