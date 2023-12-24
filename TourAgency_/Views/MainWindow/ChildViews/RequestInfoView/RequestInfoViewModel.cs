using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TourAgency_.Models.Entities;
using TourAgency_.Models.Interfaces;
using TourAgency_.Util;
using TourAgency_.ViewModels;

namespace TourAgency_.Views.MainWindow.ChildViews.RequestInfoView
{
    public class RequestInfoViewModel : ViewModelBase
    {
        private ITourRepository tourRepository;
        private IUserRepository userRepository;
        private IRequestRepository requestRepository;

        private int userId { get; set; }

        private string? reply { get; set; }
        public string? Reply { get { return reply; } set { reply = value; OnPropertyChanged(nameof(Reply)); } }
        public string DefaultOption { get; set; }

        private string? employeeName { get; set; }
        public string? EmployeeName { get { return employeeName; } set { employeeName = value; OnPropertyChanged(nameof(EmployeeName)); } }
        private string? clientName { get; set; }
        public string? ClientName { get { return clientName; } set { clientName = value; OnPropertyChanged(nameof(ClientName)); } }
        private string? imageLink { get; set; }
        public string? ImageLink { get { return imageLink; } set {imageLink = value; OnPropertyChanged(nameof(ImageLink)); } }
        private string? requestStatus { get; set; }
        public string? RequestStatusString { get { return requestStatus; } set { requestStatus = value; OnPropertyChanged(nameof(RequestStatusString)); } }

        private string tourName { get; set; }
        public string TourName { get { return tourName; } set { tourName = value; OnPropertyChanged(nameof(TourName)); } }
        private string selectedOption { get; set; }
        public string SelectedOption { get { return selectedOption; } set { selectedOption = value; OnPropertyChanged(nameof(SelectedOption)); } }

        private string arrivalDate { get; set; }
        public string ArrivalDate { get { return arrivalDate; } set { arrivalDate = value; OnPropertyChanged(nameof(ArrivalDate)); } }
        private string sendDate { get; set; }
        public string SendDate { get { return sendDate; } set { sendDate = value; OnPropertyChanged(nameof(SendDate)); } }
        private string departureDate { get; set; }
        public string DepartureDate { get { return departureDate; } set { departureDate = value; OnPropertyChanged(nameof(DepartureDate)); } }


        private int price { get; set; }
        public int Price { get { return price; } set { price = value; OnPropertyChanged(nameof(Price)); } }

        private Visibility clientControls {  get; set; }
        public Visibility ClientControls { get { return clientControls; } set { clientControls = value; OnPropertyChanged(nameof(ClientControls)); } }
        private Visibility employeeControls { get; set; }
        public Visibility EmployeeControls { get { return employeeControls; } set {employeeControls = value; OnPropertyChanged(nameof(EmployeeControls)); } }

        public ICommand ReturnTo { get; }
        public ICommand Apply { get; }
        public ViewModelCommand ReturnCommand;

        private Tour tour;
        private User employee;
        private User client;
        private Request request;

        public RequestInfoViewModel(ViewModelCommand returnTo, object requestId, UserType userType, int userId)
        {
            var kernel = new StandardKernel(new NinjectRegistrations(), new ReposModule("DbConnection"));

            this.userId = userId;

            tourRepository = kernel.Get<ITourRepository>();
            userRepository = kernel.Get<IUserRepository>();
            requestRepository = kernel.Get<IRequestRepository>();

            request = requestRepository.GetItem((int)requestId);
            employee = userRepository.GetItem(request.EmployeeId ?? -1);
            client = userRepository.GetItem(request.ClientId);
            tour = tourRepository.GetItem(request.TourId);


            if (userType == UserType.Client)
            {
                ClientControls = Visibility.Visible;
                EmployeeControls = Visibility.Collapsed;
            }
            else
            {
                ClientControls = Visibility.Collapsed;
                EmployeeControls = Visibility.Visible;
            }

            switch (request.RequestStatus)
            {
                case RequestStatus.Sent:
                    RequestStatusString = "Отправлена";
                    SelectedOption = "0";
                    break;
                case RequestStatus.Processing:
                    RequestStatusString = "На рассмотрении";
                    SelectedOption = "1";
                    break;
                case RequestStatus.Accepted:
                    RequestStatusString = "Одобрена";
                    SelectedOption = "2";
                    break;
                case RequestStatus.Denied:
                    RequestStatusString = "Отклонена";
                    SelectedOption = "3";
                    break;
            }
            DefaultOption = SelectedOption;

            TourName = tour.Name;
            ClientName = client.Name;
            if (employee != null) EmployeeName = employee.Name;

            ArrivalDate = tour.ArrivalDate.ToString();
            DepartureDate = tour.DepartureDate.ToString();
            Price = tour.Price;
            SendDate = request.SendDate.ToString() ?? "";
            Reply = request.Reply;
            ImageLink = tour.ImageLink;

            ReturnCommand = returnTo;
            ReturnTo = ReturnCommand;
            Apply = new ViewModelCommand(ApplyCommand);
        }

        private void ApplyCommand(object obj)
        {
            if (SelectedOption != DefaultOption)
            {
                MessageBoxResult result = MessageBox.Show("Вы действительно хотите изменить статус заявки?", "Подтвердить действие", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    request.Reply = Reply;
                    if (SelectedOption != "0")
                    {
                        request.EmployeeId = userId;
                        request.ConclusionDate = DateTime.Now.ToUniversalTime();
                    }
                    else
                    {
                        request.EmployeeId = null;
                        request.ConclusionDate = null;
                    }
                    switch (SelectedOption)
                    {
                        case "0":
                            request.RequestStatus = RequestStatus.Sent;
                            break;
                        case "1":
                            request.RequestStatus = RequestStatus.Processing;
                            break;
                        case "2":
                            request.RequestStatus = RequestStatus.Accepted;
                            break;
                        case "3":
                            request.RequestStatus = RequestStatus.Denied;
                            break;
                    }
                    requestRepository.Update(request);
                    ReturnCommand.Execute(obj);
                }
                else
                {

                }
            }
            else 

            if(SelectedOption != "0")
            {
                MessageBoxResult result = MessageBox.Show("Вы действительно хотите изменить ответ на заявку?", "Подтвердить действие", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    request.Reply = Reply;
                    requestRepository.Update(request);
                    ReturnCommand.Execute(obj);
                }
                else
                {

                }
            }
        }
        
    }
}
