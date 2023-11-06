using Interfaces.Repository;
using DomainLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
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
        }

        public void Delete(int id)
        {
            Employee employee = GetItem(id);
            if (employee != null)
            {
                db.Employees.Remove(employee);
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
        }
    }
}
