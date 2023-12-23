using Ninject;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TourAgency_.Models.Entities;
using TourAgency_.Models.Interfaces;
using TourAgency_.Models.Repository;
using TourAgency_.Util;
using TourAgency_.ViewModels;

namespace TourAgency_.Views.MainWindow.ChildViews.ClientRequestsView
{
    public class ClientRequestsViewModel : ViewModelBase
    {
        private int userId;
        private UserType userType;
        private IRequestRepository requestRepository;
        public ICommand Search { get; }
        public ObservableCollection<Request>? requestsList {  get; set; }
        public ObservableCollection<Request>? RequestsList { get { return requestsList; } set { requestsList = value; OnPropertyChanged(nameof(RequestsList)); } }

        public Visibility employeeButtonsVisibility { get; set; }
        public Visibility EmployeeButtonsVisibility { get { return employeeButtonsVisibility; } set { employeeButtonsVisibility = value; OnPropertyChanged(nameof(EmployeeButtonsVisibility)); } }
        public string searchName { get; set; }
        public string SearchName { get { return searchName; } set { searchName = value; OnPropertyChanged(nameof(SearchName)); } }

        public string selectedOptionUserType { get; set; }
        public string SelectedOptionUserType { get { return selectedOptionUserType; } set { selectedOptionUserType = value; OnPropertyChanged(nameof(SelectedOptionUserType)); } }

        public string selectedOptionSort { get; set; }
        public string SelectedOptionSort { get { return selectedOptionSort; } set { selectedOptionSort = value; OnPropertyChanged(nameof(SelectedOptionSort)); } }

        public ClientRequestsViewModel(int userId, UserType userType)
        {
            this.userId = userId;
            this.userType = userType;

            var kernel = new StandardKernel(new NinjectRegistrations(), new ReposModule("DbConnection"));

            requestRepository = kernel.Get<IRequestRepository>();

            if (userType == UserType.Client)
            {
                RequestsList = new ObservableCollection<Request>(requestRepository.GetRequestsByUser(userId) ?? new List<Request>());
                EmployeeButtonsVisibility = Visibility.Collapsed;
            }
            else RequestsList = new ObservableCollection<Request>(requestRepository.GetRequestsByEmployee(userId) ?? new List<Request>());
        }

        private void SearchCommand(object obj)
        {
            if (SearchName == null) SearchName = "";
            List<Request>? list = new List<Request>();
            if (userType == UserType.Employee)
            {
                switch (SelectedOptionUserType)
                {
                    case "0":
                        list = requestRepository.GetRequestsByEmployee(userId, null);
                        break;
                    case "1":
                        list = requestRepository.GetRequestsByUser(null)
                        break;
                    case "2":
                        list = requestRepository.GetListByUserNameAndType(SearchName, UserType.Employee);
                        break;
                    default:
                        goto case "0";
                }
            }


            if (list == null) list = new List<Request>();
            else
            {
                switch (SelectedOptionSort)
                {
                    case "1":
                        list = list.OrderBy(i => i.SendDate).ToList();
                        break;
                    case "2":
                        list = list.OrderByDescending(i => i.SendDate).ToList();
                        break;
                }
            }

            RequestsList = new ObservableCollection<Request>(list);
        }
    }
}
