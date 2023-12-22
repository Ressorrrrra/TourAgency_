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

namespace TourAgency_.Views.MainWindow.ChildViews.EmployeeInfoView
{
    public class EmployeeInfoViewModel : ViewModelBase
    {
        private IUserRepository userRepository;
        private IEmployeeReportService employeeReportService;
        public ViewModelCommand ReturnTo { get; }
        public ICommand CreateEmployee { get; }

        private User employee { get; set; }


        private string? name { get; set; }
        public string? Name { get { return name; } set { name = value; OnPropertyChanged(nameof(Name)); } }

        private int? employeePerfomance { get; set; }
        public int? EmployeePerfomance { get { return employeePerfomance; } set { employeePerfomance = value; OnPropertyChanged(nameof(EmployeePerfomance)); } }

        private int? selectedOption { get; set; }
        public int? SelectedOption { get { return selectedOption; } set { selectedOption = value; OnPropertyChanged(nameof(SelectedOption)); } }

        private string? profilePicture { get; set; }
        public string? ProfilePicture { get { return profilePicture; } set { profilePicture = value; OnPropertyChanged(nameof(ProfilePicture)); } }

        private string? dateOfBirth { get; set; }
        public string? DateOfBirth { get { return dateOfBirth; } set { dateOfBirth = value; OnPropertyChanged(nameof(DateOfBirth)); } }

        private string? passportNumber { get; set; }
        public string? PassportNumber { get { return passportNumber; } set { passportNumber = value; OnPropertyChanged(nameof(PassportNumber)); } }

        public ICommand CalculatePerfomance { get;  }

        public EmployeeInfoViewModel(ViewModelCommand returnTo, object employeeId)
        {
            ReturnTo = returnTo;

            var kernel = new StandardKernel(new NinjectRegistrations(), new ReposModule("DbConnection"));

            userRepository = kernel.Get<IUserRepository>();
            employeeReportService = kernel.Get<IEmployeeReportService>();

            employee = userRepository.GetItem((int)employeeId);
            Name = employee.Name;
            ProfilePicture = employee.ProfilePictureLink;
            DateOfBirth = employee.DateOfBirth.ToString();
            PassportNumber = employee.PassportNumber;

            CalculatePerfomance = new ViewModelCommand(CalculatePerfomanceCommand);
        }

        public void CalculatePerfomanceCommand(object obj)
        {
            switch (SelectedOption)
            {
                case 0:
                    DateTime now = DateTime.Now.ToUniversalTime();
                    DateTime date = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0).ToUniversalTime();
                    EmployeePerfomance = employeeReportService.EmployeePerfomanceByDate(date, employee.Id);
                    break;
                case 1:
                    now = DateTime.Now.AddDays(-7);
                    date = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
                    EmployeePerfomance = employeeReportService.EmployeePerfomanceByDate(date, employee.Id);
                    break;
                case 2:
                    now = DateTime.Now.AddMonths(-1);
                    date = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
                    EmployeePerfomance = employeeReportService.EmployeePerfomanceByDate(date, employee.Id);
                    break;
                case 4:
                    now = DateTime.Now.AddYears(-1);
                    date = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
                    EmployeePerfomance = employeeReportService.EmployeePerfomanceByDate(date, employee.Id);
                    break;
                default:
                    break;
            }
        }
    }
}
