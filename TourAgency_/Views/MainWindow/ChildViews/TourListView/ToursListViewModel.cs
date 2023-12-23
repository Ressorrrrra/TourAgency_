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
        public ICommand ViewTour { get; }

        public ICommand Search {  get; }

        public ViewModelCommand View;

        public string searchName {  get; set; }
        public string SearchName { get { return searchName; } set { searchName = value; OnPropertyChanged(nameof(SearchName)); } }

        public string selectedOption { get; set; }
        public string SelectedOption { get { return selectedOption; } set { selectedOption = value; OnPropertyChanged(nameof(SelectedOption)); } }



        public ToursListViewModel(UserType userType, ViewModelCommand add, ViewModelCommand view)
        {
            var kernel = new StandardKernel(new NinjectRegistrations(), new ReposModule("DbConnection"));
            tourRepository = kernel.Get<ITourRepository>();
            toursList = new ObservableCollection<Tour>(tourRepository.GetList());
            AddTour = add;
            View = view;
            ViewTour = new ViewModelCommand(ViewTourCommand);
            if (userType != UserType.Administrator) addButtonVisibility = Visibility.Collapsed;
            Search = new ViewModelCommand(SearchCommand);
            SelectedOption = "0";
        }

        private void ViewTourCommand(object obj)
        {
            View.Execute(obj);
        }

        private void SearchCommand(object obj)
        {
            if (SearchName == null) SearchName = "";
            var list = tourRepository.GetToursByName(SearchName);
            if (list == null) list = new List<Tour>();
            else
            {
                switch (SelectedOption)
                {
                    case "1":
                        list = list.OrderBy(i => i.Price).ToList();
                        break;
                    case "2":
                        list = list.OrderByDescending(i => i.Price).ToList();
                        break;
                }
            }

            ToursList = new ObservableCollection<Tour>(list);
        }

    }
}
