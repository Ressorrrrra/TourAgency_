﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
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
using TourAgency_.Views;
using TourAgency_.Views.MainWindow;
using TourAgency_.Views.RegistrationWindow;

namespace TourAgency_.Views.LoginWindow
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow(Action action1, Action action2)
        {
            InitializeComponent();
            this.DataContext = new LoginWindowViewModel(action1, action2);
        }

    }
}
