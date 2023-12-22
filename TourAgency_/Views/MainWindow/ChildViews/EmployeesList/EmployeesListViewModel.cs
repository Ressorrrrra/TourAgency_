using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TourAgency_.Models.Entities;
using TourAgency_.Models.Interfaces;
using TourAgency_.Util;
using TourAgency_.ViewModels;

namespace TourAgency_.Views.MainWindow.ChildViews.EmployeesList
{
    public class EmployeesListViewModel : ViewModelBase
    {
        private IUserRepository userRepository;

        public ICommand CreateEmployee { get; }

        public ICommand EmployeeInfo { get; }

        public List<User>? employees {  get; set; }
        public List<User>? Employees { get { return employees; } set { employees = value; OnPropertyChanged(nameof(Employees)); } }

        public EmployeesListViewModel(ViewModelCommand createEmployee, ViewModelCommand employeeInfo)
        {
            var kernel = new StandardKernel(new NinjectRegistrations(), new ReposModule("DbConnection"));

            userRepository = kernel.Get<IUserRepository>();

            Employees = userRepository.GetListByUserType(UserType.Employee);

            CreateEmployee = createEmployee;
            EmployeeInfo = employeeInfo;

        }


    }
}
