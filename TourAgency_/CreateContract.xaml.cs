using Interfaces.DTO;
using Interfaces.Repository;
using BLL.Services;
using DAL;
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
using Interfaces.Services;

namespace TourAgency_
{
    /// <summary>
    /// Логика взаимодействия для AddContract.xaml
    /// </summary>
    public partial class CreateContract : Window
    {
        public CreateContract()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }

        private void Employee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
