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
using Npgsql;
using System.Configuration;
using System.Data;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using NpgsqlTypes;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using BLL.Services;
using System.Diagnostics.Contracts;
using Interfaces.DTO;
using System.Xml.Linq;
using Interfaces.Services;
using Interfaces.Repository;
using Ninject;
using TourAgency_.Util;

namespace TourAgency_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //string connectionString;
        NpgsqlDataAdapter adapter;
        DataSet contractTable;

        IContractService contractService;
        IEmployeeService employeeService;
        IClientService clientService;
        ITourService tourService;
        IDirectionService directionService;
        ITransportTypeService transportTypeService;
        ITourOperatorService tourOperatorService;


        //DataTable dataTable1 = new DataTable("employee");

        private NpgsqlDataAdapter employeeAdapter;
        NpgsqlCommandBuilder employeeBuilder;

        private DataSet dataSet = new DataSet();

        public MainWindow()
        {
            var kernel = new StandardKernel(new NinjectRegistrations(), new ReposModule("DbConnection"));

            contractService = kernel.Get<IContractService>();
            employeeService = kernel.Get<IEmployeeService>();
            clientService = kernel.Get<IClientService>();
            tourService = kernel.Get<ITourService>();
            directionService = kernel.Get<IDirectionService>();
            transportTypeService = kernel.Get<ITransportTypeService>();
            tourOperatorService = kernel.Get<ITourOperatorService>();
            InitializeComponent();
            //connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            //employeeAdapter = new NpgsqlDataAdapter("SELECT * from employee", connectionString);
            //employeeBuilder =  new NpgsqlCommandBuilder(employeeAdapter);
            //employeeAdapter.Fill(dataSet, "employee");
            //employeeBuilder.GetInsertCommand();

        }

        private void Contract_Loaded(object sender, RoutedEventArgs e)
        {
            var data = contractService.GetAllContracts();
            LoadData(contract, data);
        }

        private void Employee_Loaded(object sender, RoutedEventArgs e)
        {
            var data = employeeService.GetAllEmployees();
            LoadData(employee, data);
        }

        private void Client_Loaded(object sender, RoutedEventArgs e)
        {
            var data = clientService.GetAllClients();
            LoadData(client, data);

        }

        private void Tour_Loaded(object sender, RoutedEventArgs e)
        {
            var data = tourService.GetAllTours();
            LoadData(client, data);

        }

        private void LoadData(DataGrid datagrid, object data)
        {
            datagrid.ItemsSource = (System.Collections.IEnumerable)data;
        }


        private void getConracts_Click(object sender, RoutedEventArgs e)
        {
        }

        private void employees_Loaded(object sender, RoutedEventArgs e)
        {
            //DataTable dataTable = new DataTable("employee");
            //using (NpgsqlConnection sqlConnection = new NpgsqlConnection(connectionString))
            //{
            //    employees.ItemsSource = dataSet.Tables["employee"].DefaultView;
            //}
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            //using (NpgsqlConnection sqlConnection = new NpgsqlConnection(connectionString))
            //{
            //    employeeAdapter.Update(dataSet, "employee");
            //}
        }

        private void SaveContractDataButton_Click(object sender, RoutedEventArgs e)
        {
            // ContractService service = new ContractService();

        }
        private void AddContractButton_Click(object sender, RoutedEventArgs e)
        {
            CreateContract addContractWindow = new CreateContract();
            addContractWindow.Employee.ItemsSource = employeeService.GetAllEmployees().Select(i => new { Id = i.Id, Name = i.Name }).ToList();
            addContractWindow.Client.ItemsSource = clientService.GetAllClients().Select(i => new { Id = i.Id, Name = i.Name }).ToList();
            addContractWindow.ShowDialog();

        }
        private void UpdateContractButton_Click(object sender, RoutedEventArgs e)
        {
            if (getSelectedRow(contract) is ContractDto row)
            {
                CreateContract f = new CreateContract();
                f.Employee.SelectedItem = employeeService.GetEmployee(row.EmployeeId);

                Nullable<bool> dialogResult = f.ShowDialog();
                if (dialogResult == true)
                {
                    //EmployeeDto emp = new EmployeeDto();
                    //emp.Id = row.Id;
                    //emp.Name = f.Name.Text;
                    //if (int.TryParse(f.ContractCount.Text, out int value))
                    //{
                    //    emp.ContractCount = value;
                    //}
                    //service.UpdateEmployee(emp);
                    //MessageBox.Show("Данные о сотруднике обновлены!");


                    //var data = service.GetAllEmployees();
                    //LoadData(employee, data);
                }
            }

        }
        private void DeleteContractButton_Click(object sender, RoutedEventArgs e)
        {
            if (getSelectedRow(contract) is ContractDto row)
            {
                if (MessageBox.Show($"Вы уверены, что хотите удалить контракт '{row.Id}'? Это действие вы не сможете отменить.",
                    "Удаление данных",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    string id = row.Id.ToString();
                    contractService.DeleteContract(row.Id);
                    MessageBox.Show($"Данные о контракте {id} удалены.");
                    var data = contractService.GetAllContracts();
                    LoadData(contract, data);
                }
            }

        }

        private void SaveEmployeeDataButton_Click(object sender, RoutedEventArgs e)
        {
            // ContractService service = new ContractService();

        }
        private void AddEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            CreateEmployee f = new CreateEmployee();
            Nullable<bool> dialogResult = f.ShowDialog();

            if (dialogResult == true)
            {
                EmployeeDto emp = new EmployeeDto();
                emp.Name = f.Name.Text;
                if (int.TryParse(f.ContractCount.Text, out int value))
                {
                    emp.ContractCount = value;
                }
                employeeService.CreateEmployee(emp);
                MessageBox.Show("Сотрудник добавлен!");


                var data = employeeService.GetAllEmployees();
                LoadData(employee, data);
            }
        }
        private void UpdateEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            if (getSelectedRow(employee) is EmployeeDto row)
            {
                CreateEmployee f = new CreateEmployee();
                f.Name.Text = row.Name;
                f.ContractCount.Text = row.ContractCount.ToString();
                Nullable<bool> dialogResult = f.ShowDialog();
                if (dialogResult == true)
                {
                    EmployeeDto emp = new EmployeeDto();
                    emp.Id = row.Id;
                    emp.Name = f.Name.Text;
                    if (int.TryParse(f.ContractCount.Text, out int value))
                    {
                        emp.ContractCount = value;
                    }
                    employeeService.UpdateEmployee(emp);
                    MessageBox.Show("Данные о сотруднике обновлены!");


                    var data = employeeService.GetAllEmployees();
                    LoadData(employee, data);
                }
            }

        }
        private void DeleteEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            if (getSelectedRow(employee) is EmployeeDto row)
            {
                if (MessageBox.Show($"Вы уверены, что хотите удалить данные сотрудника '{row.Name}'? Это действие вы не сможете отменить.",
                    "Удаление данных",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    string name = row.Name;
                    employeeService.DeleteEmployee(row.Id);
                    MessageBox.Show($"Данные о сотруднике '{name}' удалены.");
                    var data = employeeService.GetAllEmployees();
                    LoadData(employee, data);
                }
            }
        }

        private void SaveClientDataButton_Click(object sender, RoutedEventArgs e)
        {
            // ContractService service = new ContractService();

        }
        private void AddClientButton_Click(object sender, RoutedEventArgs e)
        {
            CreateClient f = new CreateClient();
            Nullable<bool> dialogResult = f.ShowDialog();

            if (dialogResult == true)
            {
                ClientDto cl = new ClientDto();
                cl.Name = f.Name.Text;
                cl.DateOfBirth = DateOnly.FromDateTime(f.Date.SelectedDate.Value);
                cl.PassportNumber = f.Passport.Text;
                cl.InternationalPassportNumber = f.InternationalPassport.Text;
                clientService.CreateClient(cl);
                MessageBox.Show("Сотрудник добавлен!");


                var data = clientService.GetAllClients();
                LoadData(client, data);
            }
        }
        private void UpdateClientButton_Click(object sender, RoutedEventArgs e)
        {
            if (getSelectedRow(client) is ClientDto row)
            {
                CreateClient f = new CreateClient();
                f.Name.Text = row.Name;
                f.Date.SelectedDate = row.DateOfBirth.ToDateTime(TimeOnly.Parse("10:00 AM"));
                f.Passport.Text = row.PassportNumber;
                f.InternationalPassport.Text = row.InternationalPassportNumber;

                Nullable<bool> dialogResult = f.ShowDialog();
                if (dialogResult == true)
                {
                    ClientDto cl = new ClientDto();
                    cl.Id = row.Id;
                    cl.Name = f.Name.Text;
                    cl.DateOfBirth = DateOnly.FromDateTime(f.Date.SelectedDate.Value);
                    cl.PassportNumber = f.Passport.Text;
                    cl.InternationalPassportNumber = f.InternationalPassport.Text;

                    clientService.UpdateClient(cl);
                    MessageBox.Show("Данные о клиенте обновлены!");


                    var data = clientService.GetAllClients();
                    LoadData(client, data);
                }
            }

        }
        private void DeleteClientButton_Click(object sender, RoutedEventArgs e)
        {
            if (getSelectedRow(client) is ClientDto row)
            {
                if (MessageBox.Show($"Вы уверены, что хотите удалить данные клиента '{row.Name}'? Это действие вы не сможете отменить.",
                    "Удаление данных",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    string name = row.Name;
                    clientService.DeleteClient(row.Id);
                    MessageBox.Show($"Данные о клиенте '{name}' удалены.");
                    var data = clientService.GetAllClients();
                    LoadData(client, data);
                }
            }
        }

        private void SaveTourDataButton_Click(object sender, RoutedEventArgs e)
        {
            // ContractService service = new ContractService();

        }
        private void AddTourButton_Click(object sender, RoutedEventArgs e)
        {
            CreateTour f = new CreateTour();
            f.Direction.ItemsSource = directionService.GetAllDirections().Select(i => new { Id = i.Id, Name = "Страна: " + i.Country + "| Город" + i.City}).ToList();
            f.TransportType.ItemsSource = transportTypeService.GetAllTransportTypes().Select(i => new { Id = i.Id, Name = i.Name }).ToList();
            f.TourOperator.ItemsSource = tourOperatorService.GetAllTourOperators().Select(i => new { Id = i.Id, Name = i.Name }).ToList();
            Nullable<bool> dialogResult = f.ShowDialog();

            if (dialogResult == true)
            {
                TourDto t = new TourDto();
                t.Name = f.Name.Text;
                t.Description = f.Description.Text;
                t.ArrivalDate = DateOnly.FromDateTime(f.ArrivalDate.SelectedDate.Value);
                t.DepartureDate = DateOnly.FromDateTime(f.DepartureDate.SelectedDate.Value);
                t.Direction = directionService.GetDirection((int)f.Direction.SelectedValue);
                t.TransportType = transportTypeService.GetTransportType((int)f.TransportType.SelectedValue);
                t.TourOperator = tourOperatorService.GetTourOperator((int)f.TourOperator.SelectedValue);
                if (int.TryParse(f.HotelStarsCount.Text, out int value))
                {
                    t.HotelStarsCount = value;
                }

                if (int.TryParse(f.Price.Text, out int value1))
                {
                    t.Price = value1;
                }
                tourService.CreateTour(t);
                MessageBox.Show("Тур добавлен!");


                var data = clientService.GetAllClients();
                LoadData(client, data);
            }
        }
        private void UpdateTourButton_Click(object sender, RoutedEventArgs e)
        {
            if (getSelectedRow(tour) is TourDto row)
            {
                CreateTour f = new CreateTour();
                f.Name.Text = row.Name;
                f.Description.Text = row.Description;
                f.ArrivalDate.SelectedDate = row.ArrivalDate.ToDateTime(TimeOnly.Parse("10:00 AM"));
                f.DepartureDate.SelectedDate = row.DepartureDate.ToDateTime(TimeOnly.Parse("10:00 AM"));
                f.Direction.SelectedValue = row.Direction.Id;
                f.TransportType.SelectedValue = row.TransportType.Id;
                f.TourOperator.SelectedValue = row.TourOperator.Id;
                f.Price.Text = row.Price.ToString();
                f.HotelStarsCount.Text = row.HotelStarsCount.ToString();

                Nullable<bool> dialogResult = f.ShowDialog();
                if (dialogResult == true)
                {
                    TourDto t = new TourDto();
                    t.Name = f.Name.Text;
                    t.Description = f.Description.Text;
                    t.ArrivalDate = DateOnly.FromDateTime(f.ArrivalDate.SelectedDate.Value);
                    t.DepartureDate = DateOnly.FromDateTime(f.DepartureDate.SelectedDate.Value);
                    t.Direction = directionService.GetDirection((int)f.Direction.SelectedValue);
                    t.TransportType = transportTypeService.GetTransportType((int)f.TransportType.SelectedValue);
                    t.TourOperator = tourOperatorService.GetTourOperator((int)f.TourOperator.SelectedValue);
                    if (int.TryParse(f.HotelStarsCount.Text, out int value))
                    {
                        t.HotelStarsCount = value;
                    }

                    if (int.TryParse(f.Price.Text, out int value1))
                    {
                        t.Price = value1;
                    }

                    tourService.UpdateTour(t);
                    MessageBox.Show("Данные о туре обновлены!");


                    var data = tourService.GetAllTours();
                    LoadData(tour, data);
                }
            }

        }
        private void DeleteTourButton_Click(object sender, RoutedEventArgs e)
        {
            if (getSelectedRow(tour) is TourDto row)
            {
                if (MessageBox.Show($"Вы уверены, что хотите удалить данные о туре '{row.Name}'? Это действие вы не сможете отменить.",
                    "Удаление данных",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    string name = row.Name;
                    clientService.DeleteClient(row.Id);
                    MessageBox.Show($"Данные о туре '{name}' удалены.");
                    var data = clientService.GetAllClients();
                    LoadData(client, data);
                }
            }
        }

        private object getSelectedRow(DataGrid dataGrid)
        {
            int index = -1;
            if (dataGrid.SelectedItem != null)
            {
                return dataGrid.SelectedItem;
            }
            return index;
        }

    }
}
