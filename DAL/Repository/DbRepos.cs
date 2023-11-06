using System;
using Interfaces.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLevel;

namespace DAL.Repository
{
    public class DbRepos : IDbRepos
    {
        private TourAgencyContext db;
        private ContractRepository contractRepository;
        private EmployeeRepository employeeRepository;
        public DbRepos()
        {
            db = new TourAgencyContext();
        }
        public IRepository<Contract> Contracts
        {
            get 
            {
                if (contractRepository == null)
                    contractRepository = new ContractRepository(db);
                return contractRepository;
            }
        }

        public IRepository<Employee> Employees
        {
            get
            {
                if (employeeRepository == null)
                    employeeRepository = new EmployeeRepository(db);
                return employeeRepository;
            }
        }

        public IRepository<Tour> Tours => throw new NotImplementedException();

        public IRepository<Client> Cleints => throw new NotImplementedException();

        public IReportsRepository Reports => throw new NotImplementedException();

        public int Save()
        {
            throw new NotImplementedException();
        }
    }
}
