using Interfaces.DTO;
using Interfaces.Services;
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
using Ninject;
using TourAgency_.Util;

namespace TourAgency_
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        IEmployeeService employeeService;
        IClientService clientService;
        public RegistrationWindow()
        {
            var kernel = new StandardKernel(new NinjectRegistrations(), new ReposModule("DbConnection"));

            employeeService = kernel.Get<IEmployeeService>();
            clientService = kernel.Get<IClientService>();

            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckPassword() && CheckLogin())
            {
                ClientDto cl = new ClientDto();
                cl.Name = Name.Text;
                cl.Login = Login.Text;
                cl.Password = Password.Text;
                cl.DateOfBirth = DateOnly.FromDateTime(Date.SelectedDate.Value);
                cl.PassportNumber = Passport.Text;
                cl.InternationalPassportNumber = InternationalPassport.Text;
                clientService.CreateClient(cl);
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
            var list1 = clientService.GetAllClients().Where(g => g.Login.Equals(Login) && g.Password.Equals(Password)).ToList();
            if (list1.Any())
            {
                MessageBox.Show("Пользователь с данным логином уже существует!");
                return false;
            }
            var list2 = employeeService.GetAllEmployees().Where(g => g.Login.Equals(Login) && g.Password.Equals(Password)).ToList();
            if (list2.Any())
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
