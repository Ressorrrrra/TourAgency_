using Ninject;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TourAgency_.Models.Entities;
using TourAgency_.Models.Interfaces;
using TourAgency_.Models.Repository;
using TourAgency_.Util;
using TourAgency_.ViewModels;

namespace TourAgency_.Views.MainWindow.ChildViews.EmployeesList
{
    public class EmployeesListViewModel : ViewModelBase
    {
        private IUserRepository userRepository;

        public ICommand CreateEmployee { get; }

        public ICommand EmployeeInfo { get; }
        public ICommand Search { get; }

        public ObservableCollection<User>? employees {  get; set; }
        public ObservableCollection<User>? Employees { get { return employees; } set { employees = value; OnPropertyChanged(nameof(Employees)); } }

        public string searchName { get; set; }
        public string SearchName { get { return searchName; } set { searchName = value; OnPropertyChanged(nameof(SearchName)); } }

        public string selectedOptionUserType { get; set; }
        public string SelectedOptionUserType { get { return selectedOptionUserType; } set { selectedOptionUserType = value; OnPropertyChanged(nameof(SelectedOptionUserType)); } }

        public string selectedOptionSort { get; set; }
        public string SelectedOptionSort { get { return selectedOptionSort; } set { selectedOptionSort = value; OnPropertyChanged(nameof(SelectedOptionSort)); } }

        public EmployeesListViewModel(ViewModelCommand createEmployee, ViewModelCommand employeeInfo)
        {
            SelectedOptionSort = "0";
            SelectedOptionUserType = "1";
            var kernel = new StandardKernel(new NinjectRegistrations(), new ReposModule("DbConnection"));

            userRepository = kernel.Get<IUserRepository>();
            Employees = new ObservableCollection<User>(userRepository.GetListByUserType(UserType.Employee));

            CreateEmployee = createEmployee;
            EmployeeInfo = employeeInfo;

            Search = new ViewModelCommand(SearchCommand);

        }

        private void SearchCommand(object obj)
        {
            if (SearchName == null) SearchName = "";
            List<User>? list = new List<User>();
            switch (SelectedOptionUserType)
            {
                case "0":
                    list = userRepository.GetListByUserNameAndType(SearchName, null);
                    break;
                case "1":
                    list = userRepository.GetListByUserNameAndType(SearchName, UserType.Client);
                    break;
                case "2":
                    list = userRepository.GetListByUserNameAndType(SearchName, UserType.Employee);
                    break;
                default:
                    goto case "0";
            }
            if (list == null) list = new List<User>();
            else
            {
                switch (SelectedOptionSort)
                {
                    case "1":
                        list = list.OrderBy(i => i.Name).ToList();
                        break;
                    case "2":
                        list = list.OrderByDescending(i => i.Name).ToList();
                        break;
                }
            }

            Employees = new ObservableCollection<User>(list);
        }


    }
}
