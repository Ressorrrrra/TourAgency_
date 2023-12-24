using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TourAgency_.ViewModels;
using TourAgency_.Models.Entities;
using Ninject;
using TourAgency_.Models.Interfaces;
using TourAgency_.Models.Repository;
using TourAgency_.Util;
using System.Windows;

namespace TourAgency_.Views.MainWindow.AddInDictionary
{
    public class AddInDictionaryViewModel : ViewModelBase
    {
        private IDirectionRepository directionRepository;
        private ITransportTypeRepository transportTypeRepository;
        private ITourOperatorRepository tourOperatorRepository;
        private string Option { get; set; }
        private string name { get; set; }
        public string Name { get { return name; } set { name = value; OnPropertyChanged(nameof(Name)); } }
        private string name1 { get; set; }
        public string Name1 { get { return name1; } set { name1 = value; OnPropertyChanged(nameof(Name1)); } }
        private string country { get; set; }
        public string Country { get { return country; } set { country = value; OnPropertyChanged(nameof(Country)); } }
        private Visibility countryVisibility { get; set; }
        public Visibility CountryVisibility { get { return countryVisibility; } set { countryVisibility = value; OnPropertyChanged(nameof(CountryVisibility)); } }
        public ICommand Create {  get; }
        private ViewModelCommand Close;

        public AddInDictionaryViewModel(ViewModelCommand close, object option)
        {
            Option = (string)option;
            switch (Option)
            {
                case nameof(Direction):
                    CountryVisibility = Visibility.Visible;
                    Name1 = "Город: ";
                    break;
                case nameof(TransportType):
                    CountryVisibility = Visibility.Collapsed;
                    Name1 = "Название: ";
                    break;
                case nameof(TourOperator):
                    CountryVisibility = Visibility.Collapsed;
                    Name1 = "Название: ";
                    break;
            }
            var kernel = new StandardKernel(new NinjectRegistrations(), new ReposModule("DbConnection"));
            directionRepository = kernel.Get<IDirectionRepository>();
            tourOperatorRepository = kernel.Get<ITourOperatorRepository>();
            transportTypeRepository = kernel.Get<ITransportTypeRepository>();

            Close = close;
            Create = new ViewModelCommand(CreateCommand);
        }

        public void CreateCommand(object obj)
        {
            switch (Option)
            {
                case nameof(Direction):
                    if (Country != "" && Name != "") directionRepository.Create(new Direction { City = Name, Country = this.Country });
                    Close.Execute(obj);
                    break;
                case nameof(TransportType):
                    if (Name != "") transportTypeRepository.Create(new TransportType { Name = this.Name }) ;
                    Close.Execute(obj);
                    break;
                case nameof(TourOperator):
                    if (Name != "") tourOperatorRepository.Create(new TourOperator { Name = this.Name });
                    Close.Execute(obj);
                    break;
            }
        }
    }
}
