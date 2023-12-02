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

namespace TourAgency_
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        IEmployeeService employeeService;
        IClientService clientService;

        public LoginWindow()
        {
            var kernel = new StandardKernel(new NinjectRegistrations(), new ReposModule("DbConnection"));

            employeeService = kernel.Get<IEmployeeService>();
            clientService = kernel.Get<IClientService>();

            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var list1 = clientService.GetAllClients().Where(g => g.Login.Equals(Login.Text) && g.Password.Equals(Password)).ToList();
            if (list1.Any())
            {

            }
            else
            {
                var list2 = employeeService.GetAllEmployees().Where(g => g.Login.Equals(Login.Text) && g.Password.Equals(Password)).ToList();
                if(list2.Any())
                {

                }
                else
                {
                    MessageBox.Show("Пользователь с данным логином и паролем не был найден");
                }
            }
            
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow regWindow = new RegistrationWindow();
            regWindow.ShowDialog();
        }
    }
}
