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


        //DataTable dataTable1 = new DataTable("employee");

        private NpgsqlDataAdapter employeeAdapter;
        NpgsqlCommandBuilder employeeBuilder;

        private DataSet dataSet = new DataSet();

        public MainWindow()
        {
            var kernel = new StandardKernel(new NinjectRegistrations(), new ReposModule("DbConnection"));

            contractService = kernel.Get<IContractService>();
            employeeService = kernel.Get<IEmployeeService>();
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

        private void LoadData(DataGrid datagrid, object data)
        {
            datagrid.ItemsSource = (System.Collections.IEnumerable)data;
        }


        private void getConracts_Click(object sender, RoutedEventArgs e)
        {
            //using (NpgsqlConnection sqlConnection = new NpgsqlConnection(connectionString))
            //{
            //    NpgsqlCommand sqlCommand = new NpgsqlCommand("select * from getContractsForAllEmployees(@date1,@date2)", sqlConnection)
            //    {
            //        Parameters =
            //        {
            //            new NpgsqlParameter("@date1", NpgsqlDbType.Date){Value = datePicker1.SelectedDate},
            //            new NpgsqlParameter("@date2", NpgsqlDbType.Date){Value= datePicker2.SelectedDate},
            //        }
            //    };
            //    sqlConnection.Open();
            //    sqlCommand.Prepare();
            //    DataTable dataTable = new DataTable("report1");
            //    var sqlAdapter = new NpgsqlDataAdapter(sqlCommand);
            //    sqlAdapter.Fill(dataTable);

            //    contracts.ItemsSource = dataTable.DefaultView;
            //}
            //ReportService service = new ReportService();
            //if (datePicker1.SelectedDate != null && datePicker2.SelectedDate != null)
            //{
            //    //contractsByMonth.ItemsSource = service.ExecuteProcedure(DateOnly.FromDateTime(datePicker1.SelectedDate.Value), DateOnly.FromDateTime(datePicker2.SelectedDate.Value));


            //}
            //if (int.TryParse(value.Text, out int value1))
            //{
            //    contractsByMonth.ItemsSource = service.ExecuteProcedure(value1);
            //}
            //contractsByMonth.ItemsSource = service.ExecuteProcedure(value.Text);
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
