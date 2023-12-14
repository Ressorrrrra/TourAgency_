
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
            //Bind<IEmployeeService>().To<EmployeeService>();
            //Bind<IClientService>().To<ClientService>();
            Bind<ITourRepository>().To<TourRepository>();
            //Bind<IDirectionService>().To<DirectionService>();
            //Bind<ITransportTypeService>().To<TransportTypeService>();
            //Bind<ITourOperatorService>().To<TourOperatorService>();
            Bind<IUserRepository>().To<UserRepository>();
            //Bind<IRequestService>().To<RequestService>();
            //Bind<ILoggingService>().To<UserRepository>();
        }
    }
}
