using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Intrinsics.Arm;
using TourAgency_.Models.Entities;
using TourAgency_.Models.Interfaces;

namespace TourAgency_.Models.Repository
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private TourAgencyContext db;

        public EmployeeRepository(TourAgencyContext context)
        {
            db = context;
        }
        public void Create(Employee item)
        {
            db.Employees.Add(item);
            Save(db);
        }

        public void Delete(int id)
        {
            Employee employee = GetItem(id);
            if (employee != null)
            {
                db.Employees.Remove(employee);
                Save(db);
            }
        }

        public Employee GetItem(int id)
        {
            return db.Employees.Find(id);
        }

        public List<Employee> GetList()
        {
            return db.Employees.ToList();
        }

        public void Update(Employee item)
        {
            db.Employees.Update(item);
            Save(db);
        }

        void Save(TourAgencyContext db)
        {
            db.SaveChanges();
        }
    }
}
