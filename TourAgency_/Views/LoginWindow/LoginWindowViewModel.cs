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
using TourAgency_.Models.Entities;
using TourAgency_.Models.Interfaces;
using TourAgency_.Util;
using TourAgency_.ViewModels;

namespace TourAgency_.Views.LoginWindow
{
    public class LoginWindowViewModel : ViewModelBase
    {

        Action LoginSuccess;
        Action Registration;
        public ICommand LogIn { get; }

        public ICommand Register { get; }

        private string login { get; set; }
        public string Login { get { return login; } set { login = value; OnPropertyChanged(nameof(Login)); } }
        private string password { get; set; }
        public string Password { get { return password; } set { password = value; OnPropertyChanged(nameof(Password)); } }

        IUserRepository userRepository;
        public LoginWindowViewModel(Action onSuccess, Action registration)
        {
            var kernel = new StandardKernel(new NinjectRegistrations(), new ReposModule("DbConnection"));
            userRepository = kernel.Get<IUserRepository>();
            LogIn = new ViewModelCommand(LogInCommand);
            Register = new ViewModelCommand(RegisterCommand);
            LoginSuccess = onSuccess;
            Registration = registration;
        }

        public void LogInCommand(object obj)
        {
            var user = userRepository.GetUser(Login, Password);
            if (user != null) {
                TourAgency_.Properties.Settings.Default.UserName = user.Login;
                TourAgency_.Properties.Settings.Default.Save();
                LoginSuccess.Invoke(); }
        }

        public void RegisterCommand(object obj)
        {
            Registration.Invoke();
        }


    }
}
