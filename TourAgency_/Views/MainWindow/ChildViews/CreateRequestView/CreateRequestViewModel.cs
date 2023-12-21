﻿using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using TourAgency_.Models.Entities;
using TourAgency_.Models.Interfaces;
using TourAgency_.Models.Repository;
using TourAgency_.Util;
using TourAgency_.ViewModels;

namespace TourAgency_.Views.MainWindow.ChildViews.CreateRequestView
{
    public class CreateRequestViewModel : ViewModelBase
    {
        private ITourRepository tourRepository;

        private string name { get; set; }
        public string Name { get { return name; } set { name = value; OnPropertyChanged(nameof(Name)); } }

        private string arrivalDate { get; set; }
        public string ArrivalDate { get { return arrivalDate; } set { arrivalDate = value; OnPropertyChanged(nameof(ArrivalDate)); } }
        private string departureDate { get; set; }
        public string DepartureDate { get { return departureDate; } set { departureDate = value; OnPropertyChanged(nameof(DepartureDate)); } }


        private int price { get; set; }
        public int Price { get { return price; } set { price = value; OnPropertyChanged(nameof(Price)); } }

        public ICommand ReturnTo { get; }
        public ICommand CreateRequest { get; }

        private ViewModelCommand ReturnCommand;

        public CreateRequestViewModel(int userId, int tourId, ViewModelCommand returnTo)
        {
            var kernel = new StandardKernel(new NinjectRegistrations(), new ReposModule("DbConnection"));

            tourRepository = kernel.Get<ITourRepository>();
            Tour tour = tourRepository.GetItem((int)tourId);

            Name = tour.Name;

            ArrivalDate = tour.ArrivalDate.ToString();
            DepartureDate = tour.DepartureDate.ToString();
            Price = tour.Price;

            ReturnCommand = returnTo;
            ReturnTo = ReturnCommand;

        }

        public void CreateRequestCommand(object obj)
        {

        }
    }
}