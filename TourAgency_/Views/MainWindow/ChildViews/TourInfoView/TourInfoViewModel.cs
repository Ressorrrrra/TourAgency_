using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using TourAgency_.Models.Entities;
using TourAgency_.Models.Interfaces;
using TourAgency_.Util;
using TourAgency_.ViewModels;

namespace TourAgency_.Views.MainWindow.ChildViews.TourInfoView
{
    public class TourInfoViewModel : ViewModelBase
    {
        private IDirectionRepository directionRepository;
        private ITransportTypeRepository transportTypeRepository;
        private ITourOperatorRepository tourOperatorRepository;
        private ITourRepository tourRepository;

        private string name { get; set; }
        public string Name { get { return name; } set { name = value; OnPropertyChanged(nameof(Name)); } }
        private string description { get; set; }
        public string Description { get { return description; } set { description = value; OnPropertyChanged(nameof(Description)); } }
        private string? image { get; set; }
        public string? Image { get { return image; } set { image = value; OnPropertyChanged(nameof(Image)); } }

        private string directionName { get; set; }
        public string DirectionName { get { return directionName; } set { directionName = value; OnPropertyChanged(nameof(DirectionName)); } }

        private string transportTypeName { get; set; }
        public string TransportTypeName { get { return transportTypeName; } set { transportTypeName = value; OnPropertyChanged(nameof(TransportTypeName)); } }

        private string tourOperatorName { get; set; }
        public string TourOperatorName { get { return tourOperatorName; } set { tourOperatorName = value; OnPropertyChanged(nameof(TourOperatorName)); } }

        private string arrivalDate { get; set; }
        public string ArrivalDate { get { return arrivalDate; } set { arrivalDate = value; OnPropertyChanged(nameof(ArrivalDate)); } }
        private string departureDate { get; set; }
        public string DepartureDate { get { return departureDate; } set { departureDate = value; OnPropertyChanged(nameof(DepartureDate)); } }

        private int hotelStarsCount { get; set; }
        public int HotelStarsCount { get { return hotelStarsCount; } set { hotelStarsCount = value; OnPropertyChanged(nameof(HotelStarsCount)); } }

        private int price { get; set; }
        public int Price { get { return price; } set { price = value; OnPropertyChanged(nameof(Price)); } }


        ViewModelCommand ReturnToList;
        public ICommand LoadImage { get; }



        public TourInfoViewModel(object tourId, ViewModelCommand returnToList)
        {
            var kernel = new StandardKernel(new NinjectRegistrations(), new ReposModule("DbConnection"));
            directionRepository = kernel.Get<IDirectionRepository>();
            tourOperatorRepository = kernel.Get<ITourOperatorRepository>();
            transportTypeRepository = kernel.Get<ITransportTypeRepository>();
            tourRepository = kernel.Get<ITourRepository>();
            Tour tour = tourRepository.GetItem((int)tourId);

            Name = tour.Name;
            Image = tour.ImageLink;
            var direction = directionRepository.GetItem(tour.DirectionId);
            DirectionName = direction.City + ", " + direction.Country;
            Description = tour.Description;
            TourOperatorName = tourOperatorRepository.GetItem(tour.TourOperatorId).Name;
            TransportTypeName = transportTypeRepository.GetItem(tour.TransportTypeId).Name;
            ArrivalDate = tour.ArrivalDate.ToString();
            DepartureDate = tour.DepartureDate.ToString();
            Price = tour.Price;
            HotelStarsCount = tour.HotelStarsCount;

            ReturnToList = returnToList;
        }

    }
}
