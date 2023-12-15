using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TourAgency_.ViewModels;

namespace TourAgency_.Views.MainWindow.ChildViews.AddTourView
{
    public class AddTourViewModel : ViewModelBase
    {
        private string name {  get; set; }
        public string Name { get { return name; } set { name = value; OnPropertyChanged(nameof(Name)); } }
        private string description { get; set; }
        public string Description { get { return description; } set { description = value; OnPropertyChanged(nameof(Description)); } }
        private string? image { get; set; }
        public string? Image { get { return image; } set { image = value; OnPropertyChanged(nameof(Image)); } }

        private DateOnly arrivalDate { get; set; }
        public DateOnly ArrivalDate { get { return arrivalDate; } set { arrivalDate = value; OnPropertyChanged(nameof(ArrivalDate)); } }
        private DateOnly departureDate { get; set; }
        public DateOnly DepartureDate { get { return departureDate; } set { departureDate = value; OnPropertyChanged(nameof(DepartureDate)); } }

        private int hotelStarsCount { get; set; }
        public int HotelStarsCount { get { return hotelStarsCount; } set { hotelStarsCount = value; OnPropertyChanged(nameof(HotelStarsCount)); } }



        public ICommand AddTour { get; }
        public ICommand LoadImage { get; }

        public AddTourViewModel()
        {
            
        }

    }
}
