using Ninject;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TourAgency_.Models.Entities;
using TourAgency_.Models.Interfaces;
using TourAgency_.Util;
using TourAgency_.ViewModels;

namespace TourAgency_.Views.MainWindow.ChildViews.TourListView
{
    public class ToursListViewModel : ViewModelBase
    {
        ITourRepository tourRepository;

        private Visibility addButtonVisibility;
        public Visibility AddButtonVisibility { get { return addButtonVisibility; } set { addButtonVisibility = value; OnPropertyChanged(nameof(AddButtonVisibility)); } }
        private ObservableCollection<Tour> toursList { get; set; }
        public ObservableCollection<Tour> ToursList { get { return toursList; } set { toursList = value; OnPropertyChanged(nameof(ToursList)); } }

        public ICommand AddTour { get; }



        public ToursListViewModel(UserType userType, ViewModelCommand add)
        {
            var kernel = new StandardKernel(new NinjectRegistrations(), new ReposModule("DbConnection"));
            tourRepository = kernel.Get<ITourRepository>();
            toursList = new ObservableCollection<Tour>(tourRepository.GetList());
            AddTour = add;
            if (userType != UserType.Administrator) addButtonVisibility = Visibility.Collapsed;
        }

    }
}
