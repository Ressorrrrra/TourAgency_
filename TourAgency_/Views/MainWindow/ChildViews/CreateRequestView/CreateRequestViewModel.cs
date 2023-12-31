﻿using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        private IUserRepository userRepository;
        private IRequestRepository requestRepository;

        private string? userName { get; set; }
        public string? UserName { get { return userName; } set { userName = value; OnPropertyChanged(nameof(userName)); } }

        private string tourName { get; set; }
        public string TourName { get { return tourName; } set { tourName = value; OnPropertyChanged(nameof(TourName)); } }

        private string arrivalDate { get; set; }
        public string ArrivalDate { get { return arrivalDate; } set { arrivalDate = value; OnPropertyChanged(nameof(ArrivalDate)); } }
        private string departureDate { get; set; }
        public string DepartureDate { get { return departureDate; } set { departureDate = value; OnPropertyChanged(nameof(DepartureDate)); } }


        private int price { get; set; }
        public int Price { get { return price; } set { price = value; OnPropertyChanged(nameof(Price)); } }

        public ICommand ReturnTo { get; }
        public ICommand CreateRequest { get; }

        private Tour tour;
        private User user;

        private ViewModelCommand ReturnCommand;

        public CreateRequestViewModel(object userId, object tourId, ViewModelCommand returnTo)
        {
            var kernel = new StandardKernel(new NinjectRegistrations(), new ReposModule("DbConnection"));

            tourRepository = kernel.Get<ITourRepository>();
            userRepository = kernel.Get<IUserRepository>();
            requestRepository = kernel.Get<IRequestRepository>();


            tour = tourRepository.GetItem((int)tourId);
            user = userRepository.GetItem((int)userId);

            TourName = tour.Name;
            UserName = user.Name;

            ArrivalDate = tour.ArrivalDate.ToString();
            DepartureDate = tour.DepartureDate.ToString();
            Price = tour.Price;

            ReturnCommand = returnTo;
            ReturnTo = ReturnCommand;

            CreateRequest = new ViewModelCommand(CreateRequestCommand);

        }

        public void CreateRequestCommand(object obj)
        {
            Request request = new Request();
            request.ClientId = user.Id;
            request.TourId = tour.Id;
            request.RequestStatus = RequestStatus.Sent;
            request.Price = tour.Price;
            request.SendDate = DateTime.Now.ToUniversalTime();
            requestRepository.Create(request);
            MessageBox.Show("Заявка отправлена!");
            ReturnTo.Execute(obj);
        }
    }
}
