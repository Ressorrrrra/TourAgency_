using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using TourAgency_.Models.Entities;
using TourAgency_.Models.Interfaces;
using TourAgency_.Models.Repository;
using TourAgency_.Util;
using TourAgency_.ViewModels;

namespace TourAgency_.Views.MainWindow.ChildViews.AddTourView
{
    public class AddTourViewModel : ViewModelBase
    {

        private IDirectionRepository directionRepository;
        private ITransportTypeRepository transportTypeRepository;
        private ITourOperatorRepository tourOperatorRepository;
        private ITourRepository tourRepository;

        private string name {  get; set; }
        public string Name { get { return name; } set { name = value; OnPropertyChanged(nameof(Name)); } }
        private string directionSearch { get; set; }
        public string DirectionSearch { get { return directionSearch; } set { directionSearch = value; OnPropertyChanged(nameof(DirectionSearch)); Directions = directionRepository.GetList().Where(i => i.City.Contains(DirectionSearch) || i.Country.Contains(DirectionSearch)).ToList(); } }
        private string description { get; set; }
        public string Description { get { return description; } set { description = value; OnPropertyChanged(nameof(Description)); } }
        private string? image { get; set; }
        public string? Image { get { return image; } set { image = value; OnPropertyChanged(nameof(Image)); } }

        private List<Direction> directions {  get; set; }
        public List<Direction> Directions { get { return directions; } set { directions = value; OnPropertyChanged(nameof(Directions)); } }

        private int chosenDirectionId { get; set; }
        public int ChosenDirectionId { get { return chosenDirectionId; } set { chosenDirectionId = value; OnPropertyChanged(nameof(ChosenDirectionId)); } }

        private List<int> directionsId { get; set; }
        public List<int> DirectionsId { get { return directionsId; } set { directionsId = value; OnPropertyChanged(nameof(DirectionsId)); } }

        private List<TransportType> transportTypes { get; set; }
        public List<TransportType> TransportTypes { get { return transportTypes; } set { transportTypes = value; OnPropertyChanged(nameof(TransportTypes)); } }
        private int chosenTransportTypeId { get; set; }
        public int ChosenTransportTypeId { get { return chosenTransportTypeId; } set { chosenTransportTypeId = value; OnPropertyChanged(nameof(ChosenTransportTypeId)); } }

        private List<int> transportTypesId { get; set; }
        public List<int> TransportTypesId { get { return transportTypesId; } set { transportTypesId = value; OnPropertyChanged(nameof(TransportTypesId)); } }

        private List<TourOperator> tourOperators { get; set; }
        public List<TourOperator> TourOperators { get { return tourOperators; } set { tourOperators = value; OnPropertyChanged(nameof(TourOperators)); } }

        private int chosenTourOperatorId { get; set; }
        public int ChosenTourOperatorId { get { return chosenTourOperatorId; } set { chosenTourOperatorId = value; OnPropertyChanged(nameof(ChosenTourOperatorId)); } }

        private List<int> tourOperatorsId { get; set; }
        public List<int> TourOperatorsId { get { return tourOperatorsId; } set { tourOperatorsId = value; OnPropertyChanged(nameof(TourOperatorsId)); } }

        private DateTime arrivalDate { get; set; }
        public DateTime ArrivalDate { get { return arrivalDate; } set { arrivalDate = value; OnPropertyChanged(nameof(ArrivalDate)); } }
        private DateTime departureDate { get; set; }
        public DateTime DepartureDate { get { return departureDate; } set { departureDate = value; OnPropertyChanged(nameof(DepartureDate)); } }

        private int hotelStarsCount { get; set; }
        public int HotelStarsCount { get { return hotelStarsCount; } set { hotelStarsCount = value; OnPropertyChanged(nameof(HotelStarsCount)); } }

        private int price { get; set; }
        public int Price { get { return price; } set { price = value; OnPropertyChanged(nameof(Price)); } }


        ViewModelCommand ReturnToList;
        public ICommand AddTour { get; }
        public ICommand LoadImage { get; }
        public ICommand AddDirection { get; }
        public ICommand AddTransportType { get; }
        public ICommand AddTourOperator { get; }

        private ViewModelCommand AddInDictionary { get; set; }

        public AddTourViewModel(ViewModelCommand returnToList, ViewModelCommand addInDictionary)
        {
            AddInDictionary = addInDictionary;
            ArrivalDate = DateTime.Now;
            DepartureDate = DateTime.Now;
            var kernel = new StandardKernel(new NinjectRegistrations(), new ReposModule("DbConnection"));
            directionRepository = kernel.Get<IDirectionRepository>();
            tourOperatorRepository = kernel.Get<ITourOperatorRepository>();
            transportTypeRepository = kernel.Get<ITransportTypeRepository>();
            tourRepository = kernel.Get<ITourRepository>();

            AddTour = new ViewModelCommand(AddTourCommand);
            AddDirection = new ViewModelCommand(AddDirectionCommand);
            AddTourOperator = new ViewModelCommand(AddTourOperatorCommand);
            AddTransportType = new ViewModelCommand(AddTransportTypeCommand);

            Directions = directionRepository.GetList();
            DirectionsId = Directions.Select(i => i.Id).ToList();

            TourOperators = tourOperatorRepository.GetList();
            TourOperatorsId = TourOperators.Select(i => i.Id).ToList();

            TransportTypes = transportTypeRepository.GetList();
            TransportTypesId = TransportTypes.Select(i => i.Id).ToList();

            ReturnToList = returnToList;
        }

        private void AddTourCommand(object obj)
        {
            Tour t = new Tour();
            t.Name = Name;
            t.Description = Description;
            t.Price = Price;
            t.ArrivalDate = DateOnly.FromDateTime(ArrivalDate);
            t.DepartureDate = DateOnly.FromDateTime(DepartureDate);
            t.DirectionId = ChosenDirectionId;
            t.TourOperatorId = ChosenTourOperatorId;
            t.TransportTypeId = ChosenTransportTypeId;
            t.HotelStarsCount = HotelStarsCount;
            t.ImageLink = Image;
            tourRepository.Create(t);
            MessageBox.Show("Тур создан!");
            ReturnToList.Execute(obj);
        }

        private void AddDirectionCommand(object obj)
        {
            AddInDictionary.Execute(nameof(Direction));
            Directions = directionRepository.GetList();
            DirectionsId = Directions.Select(i => i.Id).ToList();
        }

        private void AddTransportTypeCommand(object obj)
        {
            AddInDictionary.Execute(nameof(TransportType));
            TransportTypes = transportTypeRepository.GetList();
            TransportTypesId = TransportTypes.Select(i => i.Id).ToList();
        }

        private void AddTourOperatorCommand(object obj)
        {
            AddInDictionary.Execute(nameof(TourOperator));
            TourOperators = tourOperatorRepository.GetList();
            TourOperatorsId = TourOperators.Select(i => i.Id).ToList();
        }
    }
}
