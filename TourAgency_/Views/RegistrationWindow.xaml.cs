using Interfaces.DTO;
using Interfaces.Services;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TourAgency_.Util;

namespace TourAgency_.Views
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        IUserService userService;
        public RegistrationWindow()
        {
            var kernel = new StandardKernel(new NinjectRegistrations(), new ReposModule("DbConnection"));

            userService = kernel.Get<IUserService>();

            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckPassword() && CheckLogin())
            {
                UserDto u = new UserDto();
                u.Name = Name.Text;
                u.Login = Login.Text;
                u.Password = Password.Text;
                u.UserType = DomainLevel.UserType.Client;
                u.DateOfBirth = DateOnly.FromDateTime(Date.SelectedDate.Value);
                u.PassportNumber = Passport.Text;
                u.InternationalPassportNumber = InternationalPassport.Text;
                userService.CreateUser(u);
                MessageBox.Show("Учетная запись создана!");
                this.Close();
            }


        }

        private bool CheckLogin()
        {
            if (Login.Text == "")
            {
                MessageBox.Show("Логин не был введён.");
                return false;
            }
            var list = userService.GetAllUsers().Where(g => g.Login.Equals(Login) && g.Password.Equals(Password)).ToList();
            if (list.Any())
            {
                MessageBox.Show("Пользователь с данным логином уже существует!");
                return false;
            }

            return true;
        }

        private bool CheckPassword()
        {
            if (Password.Text.Length < 8)
            {
                MessageBox.Show("Длина пароля должна быть не менее 8 символов!");
                return false;
            }
            else return true;
        }
    }
}
