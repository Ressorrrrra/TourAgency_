﻿using System;
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
        private ClientRepository clientRepository;
        private TourRepository tourRepository;
        private DirectionRepository directionRepository;
        private TransportTypeRepository transportTypeRepository;
        private TourOperatorRepository tourOperatorRepository;
        private RequestStatusRepository requestStatusRepository;
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

        public IRepository<Tour> Tours
        {
            get
            {
                if (tourRepository == null)
                    tourRepository = new TourRepository(db);
                return tourRepository;
            }
        }

        public IRepository<Direction> Directions
        {
            get
            {
                if (directionRepository == null)
                    directionRepository = new DirectionRepository(db);
                return directionRepository;
            }
        }

        public IRepository<TransportType> TransportTypes
        {
            get
            {
                if (transportTypeRepository == null)
                    transportTypeRepository = new TransportTypeRepository(db);
                return transportTypeRepository;
            }
        }

        public IRepository<TourOperator> TourOperators
        {
            get
            {
                if (tourOperatorRepository == null)
                    tourOperatorRepository = new TourOperatorRepository(db);
                return tourOperatorRepository;
            }
        }


        public IRepository<Client> Clients
        {
            get
            {
                if (clientRepository == null)
                    clientRepository = new ClientRepository(db);
                return clientRepository;
            }
        }

        public IRepository<RequestStatus> RequestStatuses
        {
            get
            {
                if (requestStatusRepository == null)
                    requestStatusRepository = new RequestStatusRepository(db);
                return requestStatusRepository;
            }
        }

        public IReportsRepository Reports => throw new NotImplementedException();

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
