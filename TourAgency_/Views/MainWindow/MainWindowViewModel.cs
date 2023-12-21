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

namespace TourAgency_.Views.MainWindow
{
    class MainWindowViewModel : ViewModelBase
    {

        IUserRepository userRepository;
        ITourRepository tourRepository;

        public ICommand ToursList { get; }
        public ICommand RequestsList { get; }

        private User user;

        public ViewModelBase childContentView;

        private ToursListViewModel toursListView;
        private AddTourViewModel addTourView;

        private TourInfoViewModel tourInfoView;
        private ClientRequestsViewModel clientRequestsView;

        public ViewModelBase ChildContentView { get { return childContentView; } set { childContentView = value; OnPropertyChanged(nameof(ChildContentView)); } }
        private string username { get; set; }
        public string Username { get { return username; } set { username = value; OnPropertyChanged(nameof(Username)); } }

        private string usertype { get; set; }
        public string Usertype { get { return usertype; } set { usertype = value; OnPropertyChanged(nameof(Usertype)); } }




        public MainWindowViewModel()
        {
            var kernel = new StandardKernel(new NinjectRegistrations(), new ReposModule("DbConnection"));
            userRepository = kernel.Get<IUserRepository>();

            user = userRepository.GetUserByLogin(TourAgency_.Properties.Settings.Default.UserName);

            username = user.Login;
            usertype = user.UserType.ToString();
            toursListView = new ToursListViewModel(user.UserType, new ViewModelCommand(AddTourCommand), ReturnFromTourInfo(new ViewModelCommand(ToursListCommand)));
            addTourView = new AddTourViewModel(new ViewModelCommand(UpdatedToursListCommand));

            ChildContentView = toursListView;
            clientRequestsView = new ClientRequestsViewModel(user.Id);

            ToursList = new ViewModelCommand(ToursListCommand);
            RequestsList = new ViewModelCommand(ClientRequestsViewCommand);

        }

        private void AddTourCommand(object obj) => ChildContentView = addTourView;
        private void ToursListCommand(object obj) => ChildContentView = toursListView;
        private void UpdatedToursListCommand(object obj)
        {
            toursListView = new ToursListViewModel(user.UserType, new ViewModelCommand(AddTourCommand), ReturnFromTourInfo(new ViewModelCommand(ToursListCommand)));
            ChildContentView = toursListView;
        }

        private void ReturnFromCreateRequestCommand(object obj) => ChildContentView = tourInfoView;

        private void CreateRequestCommand(object obj) => ChildContentView = new CreateRequestViewModel(user.Id, obj, new ViewModelCommand(ReturnFromCreateRequestCommand));
        public ViewModelCommand ReturnFromTourInfo(ViewModelCommand parent)
        {
            return new ViewModelCommand(delegate (object id)
            {
                tourInfoView = new TourInfoViewModel(id, parent, new ViewModelCommand(CreateRequestCommand));
                ChildContentView = tourInfoView;
            });
        }

        private void ClientRequestsViewCommand(object obj) => ChildContentView = new ClientRequestsViewModel(user.Id);



    }
}

