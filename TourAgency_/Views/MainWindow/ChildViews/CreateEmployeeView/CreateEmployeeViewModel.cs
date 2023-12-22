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
using TourAgency_.Models.Repository;
using TourAgency_.Util;
using TourAgency_.ViewModels;

namespace TourAgency_.Views.MainWindow.ChildViews.CreateEmployeeView
{
    public class CreateEmployeeViewModel : ViewModelBase
    {
        private IUserRepository userRepository;
        public ViewModelCommand ReturnTo { get; }
        public ICommand CreateEmployee { get; }

        private string? name { get; set; }
        public string? Name { get { return name; } set { name = value; OnPropertyChanged(nameof(Name)); } }

        private string login { get; set; }
        public string Login { get { return login; } set { login = value; OnPropertyChanged(nameof(Login)); } }

        private string password { get; set; }
        public string Password { get { return password; } set { password = value; OnPropertyChanged(nameof(Password)); } }

        private string? profilePicture { get; set; }
        public string? ProfilePicture { get { return profilePicture; } set { profilePicture = value; OnPropertyChanged(nameof(ProfilePicture)); } }

        private UserType userType { get; set; }
        public UserType UserType { get { return userType; } set { userType = value; OnPropertyChanged(nameof(UserType)); } }

        private DateTime dateOfBirth { get; set; }
        public DateTime DateOfBirth { get { return dateOfBirth; } set { dateOfBirth = value; OnPropertyChanged(nameof(DateOfBirth)); } }

        private string? passportNumber { get; set; }
        public string? PassportNumber { get { return passportNumber; } set { passportNumber = value; OnPropertyChanged(nameof(PassportNumber)); } }

        public CreateEmployeeViewModel(ViewModelCommand returnTo)
        {
            ReturnTo = returnTo;

            var kernel = new StandardKernel(new NinjectRegistrations(), new ReposModule("DbConnection"));

            userRepository = kernel.Get<IUserRepository>();

            CreateEmployee = new ViewModelCommand(CreateEmployeeCommand);
        }

        public void CreateEmployeeCommand(object obj)
        {
            if (CheckPassword() && CheckLogin())
            {
                User u = new User();
                u.Name = Name;
                u.Login = Login;
                u.Password = Password;
                u.UserType = UserType.Employee;
                u.DateOfBirth = DateOnly.FromDateTime(DateOfBirth);
                u.PassportNumber = PassportNumber;
                u.ProfilePictureLink = ProfilePicture;
                userRepository.Create(u);
                MessageBox.Show("Учетная запись создана!");
                ReturnTo.Execute(obj);
            }
        }



        private bool CheckLogin()
        {
            if (Login == "")
            {
                MessageBox.Show("Логин не был введён.");
                return false;
            }
            var user = userRepository.GetUser(Login, Password);

            if (user != null)
            {
                MessageBox.Show("Пользователь с данным логином уже существует!");
                return false;
            }

            return true;
        }

        private bool CheckPassword()
        {
            if (Password.Length < 8)
            {
                MessageBox.Show("Длина пароля должна быть не менее 8 символов!");
                return false;
            }
            else return true;
        }
    }
}
