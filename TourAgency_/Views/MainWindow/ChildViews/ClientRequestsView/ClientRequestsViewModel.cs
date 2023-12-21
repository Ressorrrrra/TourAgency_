using Ninject;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourAgency_.Models.Entities;
using TourAgency_.Models.Interfaces;
using TourAgency_.Util;
using TourAgency_.ViewModels;

namespace TourAgency_.Views.MainWindow.ChildViews.ClientRequestsView
{
    public class ClientRequestsViewModel : ViewModelBase
    {
        private IRequestRepository requestRepository;
        public ObservableCollection<Request>? requestsList {  get; set; }
        public ObservableCollection<Request>? RequestsList { get { return requestsList; } set { requestsList = value; OnPropertyChanged(nameof(RequestsList)); } }

        public ClientRequestsViewModel(int userId)
        {
            var kernel = new StandardKernel(new NinjectRegistrations(), new ReposModule("DbConnection"));

            requestRepository = kernel.Get<IRequestRepository>();

            RequestsList = new ObservableCollection<Request>(requestRepository.GetRequestsByUser(userId) ?? new List<Request>());
        }
    }
}
