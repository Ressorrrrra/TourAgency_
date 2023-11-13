using Interfaces.DTO;
using Interfaces.Repository;
using DAL;
using DomainLevel;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Services;
using System.Reflection.PortableExecutable;

namespace BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IDbRepos db;

        public EmployeeService(IDbRepos repos)
        {
            db = repos;
        }

        public List<EmployeeDto> GetAllEmployees()
        {
            return db.Employees.GetList().Select(i => new EmployeeDto(i)).ToList();
        }


        public EmployeeDto GetEmployee(int Id)
        {
            return new EmployeeDto(db.Employees.GetItem(Id));
        }

        public void CreateEmployee(EmployeeDto c)
        {
            db.Employees.Create(new Employee() { Name = c.Name, ContractCount = c.ContractCount });
            db.Save();

        }



        public void UpdateEmployee(EmployeeDto p)
        {
            Employee e = db.Employees.GetItem(p.Id);
            e.Name = p.Name;
            e.ContractCount = p.ContractCount;
            db.Employees.Update(e);
            db.Save();
        }

        public void DeleteEmployee(int id)
        {
            Employee p = db.Employees.GetItem(id);
            if (p != null)
            {
                db.Employees.Delete(p.Id);
                db.Save();
            }
        }

        public bool Save(TourAgencyContext db)
        {
            if (db.SaveChanges() > 0) return true;
            return false;
        }
    }
}
