
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourAgency_.Models.Entities;

namespace TourAgency_.Models.Interfaces;

public interface IDbRepos
{
    IRepository<Contract> Contracts {  get; }
    IRepository<Employee> Employees { get; }
    IRepository<Tour> Tours { get; }
    IRepository<Client> Clients { get; }

    IRepository<Direction> Directions { get; }

    IRepository<TransportType> TransportTypes { get; }

    IRepository<TourOperator> TourOperators { get; }

    IRepository<RequestStatus> RequestStatuses { get; }
    IRepository<Request> Requests { get; }
    IRepository<User> Users { get; }
    int Save();
}
