using Ninject;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourAgency_.Models.Entities;
using TourAgency_.Models.Interfaces;
using TourAgency_.Models.Repository;
using TourAgency_.Util;
using TourAgency_.Views.MainWindow.ChildViews.AddTourView;
using TourAgency_.Views.MainWindow.ChildViews.TourInfoView;
using TourAgency_.Views.MainWindow.ChildViews.TourListView;

namespace TourAgency_.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        IUserRepository userRepository;
        ITourRepository tourRepository;

        private User user;

        public ViewModelBase childContentView;

        private ToursListViewModel toursListView;
        private AddTourViewModel addTourView;

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
            toursListView = new ToursListViewModel(user.UserType, new ViewModelCommand(AddTourCommand), new ViewModelCommand(ViewTourCommand));
            addTourView = new AddTourViewModel(new ViewModelCommand(ToursListCommand));

            ChildContentView = toursListView;
        }

        public void AddTourCommand(object obj) =>  ChildContentView = addTourView;
        public void ToursListCommand(object obj) => ChildContentView = toursListView;
        public void ViewTourCommand(object id)
        {
            ChildContentView = new TourInfoViewModel(id, new ViewModelCommand(ToursListCommand));
        }

    }
}
