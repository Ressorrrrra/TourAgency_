using Interfaces.Services;
using Ninject;
using TourAgency_.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace TourAgency_
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        //public static void Main()
        //{
        //    var kernel = new StandardKernel(new NinjectRegistrations(), new ReposModule("DbConnection"));

        //    IContractService contractServ = kernel.Get<IContractService>();
        //    IEmployeeService employeeServ = kernel.Get<IEmployeeService>();
        //    App app = new App();
        //    app.Run(new MainWindow(contractServ, employeeServ));
        //}
       
        
    }
}
