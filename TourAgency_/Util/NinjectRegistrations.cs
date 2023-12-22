
using Ninject.Modules;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourAgency_.Models.Interfaces;
using TourAgency_.Models.Repository;

namespace TourAgency_.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            //Bind<IContractRepository>().To<ContractRepository>();
            //Bind<IEmployeeRepository>().To<EmployeeRepository>();
            //Bind<IClientRepository>().To<ClientRepository>();
            Bind<ITourRepository>().To<TourRepository>();
            Bind<IDirectionRepository>().To<DirectionRepository>();
            Bind<ITransportTypeRepository>().To<TransportTypeRepository>();
            Bind<ITourOperatorRepository>().To<TourOperatorRepository>();
            Bind<IUserRepository>().To<UserRepository>();
            Bind<IRequestRepository>().To<RequestRepository>();
            Bind<IEmployeeReportService>().To<EmployeeReportService>();
            //Bind<IRequestRepository>().To<RequestRepository>();
            //Bind<ILoggingRepository>().To<UserRepository>();
        }
    }
}
