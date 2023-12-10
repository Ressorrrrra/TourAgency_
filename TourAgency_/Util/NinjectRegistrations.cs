﻿using BLL.Services;
using Ninject.Modules;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repository;

namespace TourAgency_.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IContractService>().To<ContractService>();
            Bind<IEmployeeService>().To<EmployeeService>();
            Bind<IClientService>().To<ClientService>();
            Bind<ITourService>().To<TourService>();
            Bind<IDirectionService>().To<DirectionService>();
            Bind<ITransportTypeService>().To<TransportTypeService>();
            Bind<ITourOperatorService>().To<TourOperatorService>();
            Bind<IUserService>().To<UserService>();
            Bind<IRequestService>().To<RequestService>();
            Bind<ILoggingService>().To<UserRepository>();
        }
    }
}
