using Ninject;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using TourAgency_.Models;
using TourAgency_.Models.Interfaces;
using TourAgency_.Util;
using TourAgency_.ViewModels;

namespace TourAgency_.Views.LoginWindow
{
    public class LoginWindowViewModel : ViewModelBase
    {
        public ICommand LogIn { get; }

        private string login { get; set; }
        public string Login { get { return login; } set { login = value; OnPropeertyChanged(nameof(Login)); } }
        private string password { get; set; }
        public string Password { get { return password; } set { password = value; OnPropeertyChanged(nameof(Password)); } }

        IUserRepository userRepository;
        public LoginWindowViewModel()
        {
            var kernel = new StandardKernel(new NinjectRegistrations(), new ReposModule("DbConnection"));
            userRepository = kernel.Get<IUserRepository>();
            LogIn = new ViewModelCommand(LogInCommand);

        }

        public void LogInCommand(object obj)
        {
            var user = userRepository.GetUser(Login, Password);
            if (user != null) { Debug.WriteLine("huenno"); }
        }
    }
}
