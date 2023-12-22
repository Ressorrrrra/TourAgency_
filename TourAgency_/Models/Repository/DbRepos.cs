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
    public class DbRepos : IDbRepos
    {
        private TourAgencyContext db;
        private TourRepository tourRepository;
        private DirectionRepository directionRepository;
        private TransportTypeRepository transportTypeRepository;
        private TourOperatorRepository tourOperatorRepository;
        private RequestRepository requestRepository;
        private UserRepository userRepository;
        public DbRepos()
        {
            db = new TourAgencyContext();
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


        public IRepository<Request> Requests
        {
            get
            {
                if (requestRepository == null)
                    requestRepository = new RequestRepository(db);
                return requestRepository;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }


        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
