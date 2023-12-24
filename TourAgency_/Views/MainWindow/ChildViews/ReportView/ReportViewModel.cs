using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using TourAgency_.Models.Entities;
using TourAgency_.ViewModels;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using Ninject;
using TourAgency_.Models.Interfaces;
using TourAgency_.Models.Repository;
using TourAgency_.Util;
using TourAgency_.Models.DTO;
using System.Formats.Asn1;
using System.Globalization;
using System.Windows;

namespace TourAgency_.Views.MainWindow.ChildViews.ReportView
{
    public class ReportViewModel : ViewModelBase
    {
        private IEmployeeReportService employeeReportService;
        private IRequestRepository requestRepository;
        private Visibility employeeReportVisibility { get; set; }
        public Visibility EmployeeReportVisibility{ get { return employeeReportVisibility; } set { employeeReportVisibility = value; OnPropertyChanged(nameof(EmployeeReportVisibility)); } }

        private Visibility tourReportVisibility { get; set; }
        public Visibility TourReportVisibility { get { return tourReportVisibility; } set { tourReportVisibility = value; OnPropertyChanged(nameof(TourReportVisibility)); } }
        private int totalTours {  get; set; }
        public int TotalTours { get { return totalTours; } set { totalTours = value; OnPropertyChanged(nameof(TotalTours)); } }
        private int totalRequests { get; set; }
        public int TotalRequests { get { return totalRequests; } set { totalRequests = value; OnPropertyChanged(nameof(TotalRequests)); } }
        private int totalIncome { get; set; }
        public int TotalIncome { get { return totalIncome; } set { totalIncome = value; OnPropertyChanged(nameof(TotalIncome)); } }
        private DateTime? date1 { get; set; }
        public DateTime? Date1 { get { return date1; } set { date1 = value; OnPropertyChanged(nameof(Date1)); } }
        private DateTime? date2 { get; set; }
        public DateTime? Date2 { get { return date2; } set { date2 = value; OnPropertyChanged(nameof(Date2)); } }
        private ObservableCollection<TourDto> mostPopularTours { get; set; }
        public ObservableCollection<TourDto> MostPopularTours { get { return mostPopularTours; } set { mostPopularTours = value; OnPropertyChanged(nameof(MostPopularTours)); } }
        private ObservableCollection<UserDto> mostEfficientEmployees { get; set; }
        public ObservableCollection<UserDto> MostEfficientEmployees { get { return mostEfficientEmployees; } set { mostEfficientEmployees = value; OnPropertyChanged(nameof(MostEfficientEmployees)); } }
        private string selectedOption { get; set; }
        public string SelectedOption { get { return selectedOption; } set { selectedOption = value; OnPropertyChanged(nameof(SelectedOption)); } }
        public ICommand CreateReport { get; }
        public ICommand DownloadReport { get; }

        public ReportViewModel()
        {
            var kernel = new StandardKernel(new NinjectRegistrations(), new ReposModule("DbConnection"));

            employeeReportService = kernel.Get<IEmployeeReportService>();
            requestRepository = kernel.Get<IRequestRepository>();

            Date1 = DateTime.MinValue.ToUniversalTime();
            Date2 = DateTime.Now.ToUniversalTime();

            DownloadReport = new ViewModelCommand(DownloadReportCommand);
            CreateReport = new ViewModelCommand(CreateReportCommand);

            SelectedOption = "1";
            CreateReportCommand("");
        }

        private void DownloadReportCommand(object obj)
        {
            string _filePath = OpenFolderDialog();

            if (!string.IsNullOrEmpty(_filePath))
            {


                switch (SelectedOption)
                {
                    case "0":
                        string filePath = Path.Combine(_filePath, "reportSales.csv");
                        Dictionary<string, int?> data = new Dictionary<string, int?>();
                        data.Add("Продано туров", TotalTours);
                        data.Add("Доход", TotalIncome);
                        data.Add("Самые продаваемые туры", null);
                        foreach (var item in MostPopularTours)
                        {
                            data.Add(item.Tour.Name, item.SoldAmount);
                        }

                        GenerateCsvReport(data, filePath);
                        break;
                    case "1":
                        filePath = Path.Combine(_filePath, "reportEmployees.csv");
                        data = new Dictionary<string, int?>();
                        data.Add("Обработано заявок", TotalRequests);
                        data.Add("Самые эффективные работники", null);
                        foreach (var item in MostEfficientEmployees)
                        {
                            data.Add(item.User.Name, item.Count);
                        }

                        GenerateCsvReport(data, filePath);

                        break;
                }

            }
        }

        public string OpenFolderDialog()
        {
            var openFileDialog = new OpenFileDialog
            {
                Title = "Выберите папку",
                Filter = "Все файлы (*.*)|*.*",
                CheckFileExists = false,
                CheckPathExists = true,
                FileName = "Папка выбора"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                return Path.GetDirectoryName(openFileDialog.FileName);
            }

            return null;
        }


        private void CreateReportCommand(object obj)
        {
            switch (SelectedOption)
            {
                case "0":
                    CreateTourReport();
                    break;
                case "1":
                    CreateEmployeeReport();
                    break;
            }
        }

        private void CreateTourReport()
        {
            EmployeeReportVisibility = Visibility.Collapsed;
            TourReportVisibility = Visibility.Visible;
            var _date1 = Date1.Value.ToUniversalTime();
            var _date2 = Date2.Value.ToUniversalTime();
            TotalTours = requestRepository.GetSoldToursAmount(_date1, _date2);
            TotalIncome = requestRepository.GetIncome(_date1, _date2);
            MostPopularTours = new ObservableCollection<TourDto>(requestRepository.GetMostPopularTours(_date1, _date2, 5) ?? new List<TourDto>());
        }

        private void CreateEmployeeReport()
        {
            EmployeeReportVisibility = Visibility.Visible;
            TourReportVisibility = Visibility.Collapsed;
            var _date1 = Date1.Value.ToUniversalTime();
            var _date2 = Date2.Value.ToUniversalTime();
            TotalRequests = requestRepository.GetCountOfNonFreeRequest(_date1, _date2);
            MostEfficientEmployees = new ObservableCollection<UserDto>(employeeReportService.GetMostEfficientEmployees(_date1, _date2, 5) ?? new List<UserDto>());
        }

        public static void GenerateCsvReport(Dictionary<string, int?> data, string filePath)
        {
            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                ShouldUseConstructorParameters = _ => false 
            };

            using (var writer = new StreamWriter(filePath, false, Encoding.UTF8))
            using (var csv = new CsvWriter(writer, csvConfig))
            {
                csv.WriteRecords(data.Select(item => new { Name = item.Key, Count = item.Value }));
            }
        }

    }
}
