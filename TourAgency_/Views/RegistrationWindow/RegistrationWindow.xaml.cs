﻿
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
using TourAgency_.Models.Interfaces;
using TourAgency_.ViewModels;

namespace TourAgency_.Views.RegistrationWindow
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {



        public RegistrationWindow(Action action1)
        {
            InitializeComponent();
            this.DataContext = new RegistrationWindowViewModel(action1);
        }

    }
}
