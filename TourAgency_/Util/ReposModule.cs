﻿
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourAgency_.Models.Repository;
using TourAgency_.Models.Interfaces;

namespace TourAgency_.Util
{
    public class ReposModule : NinjectModule
    {
        private string connectionString;
        public ReposModule(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {
            Bind<IDbRepos>().To<DbRepos>().InSingletonScope().WithConstructorArgument(connectionString);
        }
    }
}
