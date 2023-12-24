using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourAgency_.Models.Entities;
using TourAgency_.Models.Interfaces;
using TourAgency_.Util;
using TourAgency_.ViewModels;
using TourAgency_.Views.MainWindow.ChildViews.AddTourView;
using TourAgency_.Views.MainWindow.ChildViews.TourInfoView;
using TourAgency_.Views.MainWindow.ChildViews.TourListView;
using TourAgency_.Views.MainWindow.ChildViews.CreateRequestView;
using TourAgency_.Views.MainWindow.ChildViews.ClientRequestsView;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.Windows;
using TourAgency_.Views.MainWindow.ChildViews.EmployeesList;
using TourAgency_.Views.MainWindow.ChildViews.CreateEmployeeView;
using TourAgency_.Views.MainWindow.ChildViews.EmployeeInfoView;
using TourAgency_.Views.MainWindow.ChildViews.RequestInfoView;
using TourAgency_.Views.MainWindow.ChildViews.ReportView;

namespace TourAgency_.Views.MainWindow
{
    class MainWindowViewModel : ViewModelBase
    {

        IUserRepository userRepository;
        ITourRepository tourRepository;

        public Visibility employeeButtonVisibility {  get; set; }
        public Visibility EmployeeButtonVisibility { get { return employeeButtonVisibility; } set { employeeButtonVisibility = value; OnPropertyChanged(nameof(EmployeeButtonVisibility)); } }
        public Visibility requestsButtonVisibility { get; set; }
        public Visibility RequestsButtonVisibility { get { return requestsButtonVisibility; } set { requestsButtonVisibility = value; OnPropertyChanged(nameof(RequestsButtonVisibility)); } }
        public Visibility reportsButtonVisibility { get; set; }
        public Visibility ReportsButtonVisibility { get { return reportsButtonVisibility; } set { reportsButtonVisibility = value; OnPropertyChanged(nameof(ReportsButtonVisibility)); } }
        public ICommand ToursList { get; }
        public ICommand RequestsList { get; }

        public ICommand EmployeesList { get; }
        public ICommand EmployeeInfo { get; }
        public ICommand Report { get; }
        public ICommand LogOut { get; }

        private User user;

        public ViewModelBase childContentView;

        private ToursListViewModel toursListView;
        private AddTourViewModel addTourView;

        private TourInfoViewModel tourInfoView;
        private ClientRequestsViewModel? clientRequestsView;
        private EmployeesListViewModel? employeesListView;

        private ReportViewModel? reportView;

        public ViewModelBase ChildContentView { get { return childContentView; } set { childContentView = value; OnPropertyChanged(nameof(ChildContentView)); } }
        private string username { get; set; }
        public string Username { get { return username; } set { username = value; OnPropertyChanged(nameof(Username)); } }
        private string? profilePicture { get; set; }
        public string? ProfilePicture { get { return profilePicture; } set { profilePicture = value; OnPropertyChanged(nameof(ProfilePicture)); } }


        private string usertype { get; set; }
        public string Usertype { get { return usertype; } set { usertype = value; OnPropertyChanged(nameof(Usertype)); } }




        public MainWindowViewModel(ViewModelCommand logout, ViewModelCommand addDictionary)
        {
            var kernel = new StandardKernel(new NinjectRegistrations(), new ReposModule("DbConnection"));
            userRepository = kernel.Get<IUserRepository>();

            user = userRepository.GetUserByLogin(TourAgency_.Properties.Settings.Default.UserName);

            username = user.Login;
            usertype = user.UserType.ToString();
            ProfilePicture = user.ProfilePictureLink;

            if (user.UserType != UserType.Administrator)
            {
                ReportsButtonVisibility = Visibility.Collapsed;
                EmployeeButtonVisibility = Visibility.Collapsed;
                RequestsButtonVisibility = Visibility.Visible;
            }
            else
            {
                RequestsButtonVisibility = Visibility.Collapsed;
                EmployeeButtonVisibility = Visibility.Visible;
                ReportsButtonVisibility = Visibility.Visible;
            }

                addTourView = new AddTourViewModel(new ViewModelCommand(UpdatedToursListCommand), addDictionary);
            toursListView = new ToursListViewModel(user.UserType, new ViewModelCommand(AddTourCommand), ReturnFromTourInfo(new ViewModelCommand(ToursListCommand)));

            ChildContentView = toursListView;
            clientRequestsView = new ClientRequestsViewModel(user.Id, new ViewModelCommand(RequestInfoCommand), user.UserType);

            ToursList = new ViewModelCommand(ToursListCommand);
            RequestsList = new ViewModelCommand(ClientRequestsViewCommand);
            EmployeesList = new ViewModelCommand(EmployeesListCommand);
            EmployeeInfo = new ViewModelCommand(EmployeeInfoCommand);
            Report = new ViewModelCommand(ReportCommand);
            LogOut = logout;
        }

        private void AddTourCommand(object obj)
        { 
            ChildContentView = addTourView;
        }

        private void ReportCommand(object obj)
        {
            if (reportView == null) reportView = new ReportViewModel();
            ChildContentView = reportView;
        }
        private void RequestInfoCommand(object requestId) => ChildContentView = new RequestInfoViewModel(new ViewModelCommand(UpdatedClientRequestsViewCommand), requestId, user.UserType, user.Id);
        private void ToursListCommand(object obj) => ChildContentView = toursListView;
        private void UpdatedToursListCommand(object obj)
        {
            toursListView = new ToursListViewModel(user.UserType, new ViewModelCommand(AddTourCommand), ReturnFromTourInfo(new ViewModelCommand(ToursListCommand)));
            ChildContentView = toursListView;
        }

        private void EmployeesListCommand(object obj)
        {
            if (employeesListView == null) employeesListView = new EmployeesListViewModel(new ViewModelCommand(CreateEmployeeeCommand), new ViewModelCommand(EmployeeInfoCommand));
            ChildContentView = employeesListView;
        }

        private void EmployeeInfoCommand(object obj)
        {
            ChildContentView = new EmployeeInfoViewModel(new ViewModelCommand(EmployeesListCommand), obj);
        }

        private void CreateEmployeeeCommand(object obj)
        {
            ChildContentView = new CreateEmployeeViewModel(new ViewModelCommand(UpdatedEmployeesListCommand));
        }

        private void UpdatedEmployeesListCommand(object obj)
        {
            employeesListView = new EmployeesListViewModel(new ViewModelCommand(CreateEmployeeeCommand), new ViewModelCommand(EmployeeInfoCommand));
            ChildContentView = toursListView;
        }

        private void ReturnFromCreateRequestCommand(object obj) => ChildContentView = tourInfoView;

        private void CreateRequestCommand(object obj) => ChildContentView = new CreateRequestViewModel(user.Id, obj, new ViewModelCommand(ReturnFromCreateRequestCommand));
        public ViewModelCommand ReturnFromTourInfo(ViewModelCommand parent)
        {
            return new ViewModelCommand(delegate (object id)
            {
                tourInfoView = new TourInfoViewModel(id, parent, new ViewModelCommand(CreateRequestCommand), user.UserType);
                ChildContentView = tourInfoView;
            });
        }

        private void ClientRequestsViewCommand(object obj) => ChildContentView = new ClientRequestsViewModel(user.Id, new ViewModelCommand(RequestInfoCommand), user.UserType);

        private void UpdatedClientRequestsViewCommand(object obj)
        {
            clientRequestsView = new ClientRequestsViewModel(user.Id, new ViewModelCommand(RequestInfoCommand), user.UserType);
            ChildContentView = clientRequestsView;
        }

    }
}

