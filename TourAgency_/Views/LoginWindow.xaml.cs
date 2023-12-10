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
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        IUserService userService;

        public LoginWindow()
        { 
            var kernel = new StandardKernel(new NinjectRegistrations(), new ReposModule("DbConnection"));

            userService = kernel.Get<IUserService>();

            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var user = userService.GetUser(Login.Text, Password.Text);
            if (user != null)
            {
                MainWindow f = new MainWindow(user);
                f.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Пользователь с данным логином и паролем не был найден");
            }

        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow regWindow = new RegistrationWindow();
            regWindow.ShowDialog();
        }
    }
}
