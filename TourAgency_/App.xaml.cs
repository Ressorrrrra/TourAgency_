
using Ninject;
using TourAgency_.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TourAgency_.Views.LoginWindow;
using TourAgency_.Views.MainWindow;
using TourAgency_.Views.RegistrationWindow;
using TourAgency_.Views.MainWindow.AddInDictionary;

namespace TourAgency_
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        MainWindow m;
        LoginWindow l;
        RegistrationWindow r;
        AddInDictionary a;
        public void main1(object sender, EventArgs e)
        {
            var kernel = new StandardKernel(new NinjectRegistrations(), new ReposModule("DbConnection"));
            l = new LoginWindow(OpenMainWindow, OpenRegistrationWindow);
            l.Show();

        }

        private void OpenMainWindow()
        {
            m = new MainWindow(new ViewModels.ViewModelCommand(Logout), new ViewModels.ViewModelCommand(AddInDictionary));
            m.Show();
            l.Close();


        }

        private void AddInDictionary(object obj)
        {
            a = new AddInDictionary(new ViewModels.ViewModelCommand(CloseAddInDictionary), obj);
            a.ShowDialog();
            a.Activate();
        }

        private void CloseAddInDictionary(object obj) 
        {
            a.Close();
        }

        private void Logout(object obj)
        {
            l = new LoginWindow(OpenMainWindow, OpenRegistrationWindow);
            l.Show();
            m.Close();
        }

        private void OpenRegistrationWindow()
        {
            r = new RegistrationWindow(CloseRegistrationWindow);
            r.ShowDialog();
        }

        private void CloseRegistrationWindow()
        {
            r.Close();
        }

    }
}
