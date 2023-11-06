using Interfaces.DTO;
using DomainLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Repository
{
    public interface IDbRepos
    {
        IRepository<Contract> Contracts {  get; }
        IRepository<Employee> Employees { get; }
        IRepository<Tour> Tours { get; }
        IRepository<Client> Cleints { get; }
        IReportsRepository Reports {  get; }
        int Save();
    }
}
