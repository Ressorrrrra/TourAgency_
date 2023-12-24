using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TourAgency_.Models.Entities;
using TourAgency_.Models.Interfaces;
using TourAgency_.Models.Repository;
using TourAgency_.Util;
using TourAgency_.ViewModels;

namespace TourAgency_.Views.MainWindow.ChildViews.EmployeeInfoView
{
    public class EmployeeInfoViewModel : ViewModelBase
    {
        private IUserRepository userRepository;
        private IEmployeeReportService employeeReportService;
        private IRequestRepository requestRepository;
        public ViewModelCommand ReturnTo { get; }
        public ICommand CreateEmployee { get; }

        private User user { get; set; }

        private string login { get; set; }
        public string Login { get { return login; } set { login = value; OnPropertyChanged(nameof(Login)); } }

        private string password { get; set; }
        public string Password { get { return password; } set { password = value; OnPropertyChanged(nameof(Password)); } }
        private string? name { get; set; }
        public string? Name { get { return name; } set { name = value; OnPropertyChanged(nameof(Name)); } }

        private int? employeePerfomance { get; set; }
        public int? EmployeePerfomance { get { return employeePerfomance; } set { employeePerfomance = value; OnPropertyChanged(nameof(EmployeePerfomance)); } }
        private int? clientTours { get; set; }
        public int? ClientTours { get { return clientTours; } set { clientTours = value; OnPropertyChanged(nameof(ClientTours)); } }

        private int? selectedOption { get; set; }
        public int? SelectedOption { get { return selectedOption; } set { selectedOption = value; OnPropertyChanged(nameof(SelectedOption)); } }

        private string? profilePicture { get; set; }
        public string? ProfilePicture { get { return profilePicture; } set { profilePicture = value; OnPropertyChanged(nameof(ProfilePicture)); } }

        private string? dateOfBirth { get; set; }
        public string? DateOfBirth { get { return dateOfBirth; } set { dateOfBirth = value; OnPropertyChanged(nameof(DateOfBirth)); } }

        private string? passportNumber { get; set; }
        public string? PassportNumber { get { return passportNumber; } set { passportNumber = value; OnPropertyChanged(nameof(PassportNumber)); } }
        private string? internationalPassportNumber { get; set; }
        public string? InternationalPassportNumber { get { return internationalPassportNumber; } set { internationalPassportNumber = value; OnPropertyChanged(nameof(InternationalPassportNumber)); } }
        private Visibility clientControls {  get; set; }
        public Visibility ClientControls { get { return clientControls; } set { clientControls = value; OnPropertyChanged(nameof(ClientControls)); } }

        private Visibility employeeControls { get; set; }
        public Visibility EmployeeControls { get { return employeeControls; } set { employeeControls = value; OnPropertyChanged(nameof(EmployeeControls)); } }

        public ICommand CalculatePerfomance { get;  }

        public EmployeeInfoViewModel(ViewModelCommand returnTo, object userId)
        {
            ReturnTo = returnTo;

            var kernel = new StandardKernel(new NinjectRegistrations(), new ReposModule("DbConnection"));

            userRepository = kernel.Get<IUserRepository>();
            employeeReportService = kernel.Get<IEmployeeReportService>();
            requestRepository = kernel.Get<IRequestRepository>();

            user = userRepository.GetItem((int)userId);

            switch (user.UserType)
            {
                case UserType.Client:
                    ClientControls = Visibility.Visible;
                    EmployeeControls = Visibility.Collapsed;
                    break;
                case UserType.Employee:
                    ClientControls = Visibility.Collapsed;
                    EmployeeControls = Visibility.Visible;
                    break;
                case UserType.Administrator:
                    ClientControls = Visibility.Visible;
                    EmployeeControls = Visibility.Collapsed;
                    break;
            }
            Name = user.Name;
            Login = user.Login;
            Password = user.Password;
            ProfilePicture = user.ProfilePictureLink;
            DateOfBirth = user.DateOfBirth.ToString();
            PassportNumber = user.PassportNumber;
            InternationalPassportNumber = user.InternationalPassportNumber;
            CalculatePerfomance = new ViewModelCommand(CalculatePerfomanceCommand);
        }

        public void CalculatePerfomanceCommand(object obj)
        {
            switch (SelectedOption)
            {
                case 0:
                    DateTime now = DateTime.Now.ToUniversalTime();
                    DateTime date = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0).ToUniversalTime();
                    EmployeePerfomance = employeeReportService.EmployeePerfomanceByDate(date, user.Id);
                    ClientTours = requestRepository.GetRequestsByUserAndStatus(user.Id, RequestStatus.Accepted).Count;
                    break;
                case 1:
                    now = DateTime.Now.AddDays(-7);
                    date = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
                    EmployeePerfomance = employeeReportService.EmployeePerfomanceByDate(date, user.Id);
                    ClientTours = requestRepository.GetRequestsByUserAndStatus(user.Id, RequestStatus.Accepted).Count;
                    break;
                case 2:
                    now = DateTime.Now.AddMonths(-1);
                    date = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
                    EmployeePerfomance = employeeReportService.EmployeePerfomanceByDate(date, user.Id);
                    ClientTours = requestRepository.GetRequestsByUserAndStatus(user.Id, RequestStatus.Accepted).Count;
                    break;
                case 3:
                    now = DateTime.Now.AddYears(-1);
                    date = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
                    EmployeePerfomance = employeeReportService.EmployeePerfomanceByDate(date, user.Id);
                    ClientTours = requestRepository.GetRequestsByUserAndStatus(user.Id, RequestStatus.Accepted).Count;
                    break;
                default:
                    break;
            }
        }
    }
}
