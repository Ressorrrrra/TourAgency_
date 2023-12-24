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
using TourAgency_.ViewModels;

namespace TourAgency_.Views.MainWindow.AddInDictionary
{
    /// <summary>
    /// Логика взаимодействия для AddInDictionary.xaml
    /// </summary>
    public partial class AddInDictionary : Window
    {
        public AddInDictionary(ViewModelCommand close, object option)
        {
            InitializeComponent();
            this.DataContext = new AddInDictionaryViewModel(close, option);
        }
    }
}
