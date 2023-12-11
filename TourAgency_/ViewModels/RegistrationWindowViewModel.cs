
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using TourAgency_.Models.Interfaces;
using TourAgency_.Models.Entities;
using TourAgency_.Util;


namespace TourAgency_.ViewModels
{
    public class RegistrationWindowViewModel : ViewModelBase
    {
        private string? name { get; set; }
        public string? Name { get { return name; } set { name = value ; OnPropeertyChanged(nameof(Name)); } }

        private string login { get; set; }
        public string Login { get { return login; } set { login = value; OnPropeertyChanged(nameof(Login)); } }

        private string password { get; set; }
        public string Password { get { return password; } set { password = value; OnPropeertyChanged(nameof(Password)); } }

        private UserType userType { get; set; }
        public UserType UserType { get { return userType; } set { userType = value; OnPropeertyChanged(nameof(UserType)); } }

        private DateOnly? dateOfBirth { get; set; }
        public DateOnly? DateOfBirth { get { return dateOfBirth; } set { dateOfBirth = value; OnPropeertyChanged(nameof(DateOfBirth)); } }

        private string? passportNumber {  get; set; }
        public string? PassportNumber { get { return passportNumber; } set { passportNumber = value; OnPropeertyChanged(nameof(PassportNumber)); } }
        private string? internationalPassportNumber { get; set; }
        public string? InternationalPassportNumber { get { return internationalPassportNumber; } set { internationalPassportNumber = value; OnPropeertyChanged(nameof(InternationalPassportNumber)); } }

        IUserRepository userRepository;

        public ICommand CreateAccount { get; }


        public RegistrationWindowViewModel()
        {
            var kernel = new StandardKernel(new NinjectRegistrations(), new ReposModule("DbConnection"));

            userRepository = kernel.Get<IUserRepository>();

            CreateAccount = new ViewModelCommand(CreateAcc);
        }

        private void CreateAcc(object obj)
        {
            if (CheckPassword() && CheckLogin())
            {
                User u = new User();
                u.Name = Name;
                u.Login = Login;
                u.Password = Password;
                u.UserType = UserType.Client;
                u.DateOfBirth =DateOfBirth;
                u.PassportNumber = PassportNumber;
                u.InternationalPassportNumber = InternationalPassportNumber;
                userRepository.Create(u);
                MessageBox.Show("Учетная запись создана!");
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
