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

namespace TourAgency_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connectionString;
        NpgsqlDataAdapter adapter;
        DataSet contractTable;

        private NpgsqlDataAdapter phoneAdapter;
        private NpgsqlDataAdapter orderAdapter;
        private NpgsqlDataAdapter manufacturerAdapter;

        private DataSet dataSet = new DataSet();

        public MainWindow()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

            // Создание объектов NpgsqlDataAdapter.
            //phoneAdapter = new NpgsqlDataAdapter("Select id,name,cost, p.\"manufacturerId\" from phone p;", connectionString);
            //orderAdapter = new NpgsqlDataAdapter("Select * from \"order\";", connectionString);
            //manufacturerAdapter = new NpgsqlDataAdapter("Select * from manufacturer", connectionString);

            //// Автоматическая генерация команд SQL.
            //phoneBuilder = new NpgsqlCommandBuilder(phoneAdapter);
            //orderBuilder = new NpgsqlCommandBuilder(orderAdapter);

            //// Заполнение таблиц в DataSet.
            //phoneAdapter.Fill(dataSet, "phone");
            //orderAdapter.Fill(dataSet, "order");
            //manufacturerAdapter.Fill(dataSet, "manufacturer");

            //// Связывание элементов управления с данными.


            //dataGridViewPhones.DataSource = dataSet.Tables["phone"]; 
            //dataGridViewOrders.DataSource = dataSet.Tables["order"];
        }

        private void Contract_Loaded(object sender, RoutedEventArgs e)
        {
            string sql = "SELECT contract.id, employee.full_name, total_cost, conclusion_date FROM contract " +
                "join employee on contract.employee = employee.id";
            //DbSet<ContractData> data;
            //contractTable = new DataSet();
            //NpgsqlConnection connection = null;
            //connection = new NpgsqlConnection(connectionString);
            //NpgsqlCommand command = new NpgsqlCommand(sql, connection);
            //adapter = new NpgsqlDataAdapter(command);

            //connection.Open();
            //adapter.Fill(contractTable, "LIST");

            using (NpgsqlConnection sqlConnection = new NpgsqlConnection(connectionString))
            {
                sqlConnection.Open();
                NpgsqlCommand sqlCommand =
                    new NpgsqlCommand("SELECT contract.id, employee.full_name, total_cost, conclusion_date FROM contract " +
                "join employee on contract.employee = employee.id", sqlConnection);
                NpgsqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                DataTable dataTable = new DataTable("report1");
                dataTable.Columns.Add("ID");
                dataTable.Columns.Add("ФИО сотрудника");
                dataTable.Columns.Add("Стоимость");
                dataTable.Columns.Add("Дата заключения");

                while (sqlDataReader.Read())
                {
                    DataRow row = dataTable.NewRow();
                    row["ID"] = sqlDataReader["id"];
                    row["ФИО сотрудника"] = sqlDataReader["full_name"];
                    row["Стоимость"] = sqlDataReader["total_cost"];
                    row["Дата заключения"] = sqlDataReader["conclusion_date"];
                    dataTable.Rows.Add(row);
                }
                sqlDataReader.Close();

                contract.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = dataTable });

            }


        }

        private void FillContractData()
        {

        }

        private void getConracts_Click(object sender, RoutedEventArgs e)
        {
            using (NpgsqlConnection sqlConnection = new NpgsqlConnection(connectionString))
            {
                NpgsqlCommand sqlCommand = new NpgsqlCommand("select * from getContractsForAllEmployees(@date1,@date2)", sqlConnection)
                {
                    Parameters =
                    {
                        new NpgsqlParameter("@date1", NpgsqlDbType.Date){Value = datePicker1.SelectedDate},
                        new NpgsqlParameter("@date2", NpgsqlDbType.Date){Value= datePicker2.SelectedDate},
                    }
                };
                sqlConnection.Open();
                sqlCommand.Prepare();
                DataTable dataTable = new DataTable("report1");
                var sqlAdapter = new NpgsqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(dataTable);

                contracts.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = dataTable });
            }
        }
    }
}
