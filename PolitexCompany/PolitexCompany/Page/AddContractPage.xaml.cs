using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using static ScottPlot.Generate;
using DateTime = System.DateTime;

namespace PolitexCompany.Page
{
    /// <summary>
    /// Логика взаимодействия для AddContractPage.xaml
    /// </summary>
    public partial class AddContractPage
    {

        private static Contracts _currentPaymentsUser = new Contracts();
        public AddContractPage()
        {
            InitializeComponent();
            cbIdClient.ItemsSource = MediCarePlusEntities.GetContext().Clients.ToList();
            cbMedical.ItemsSource = MediCarePlusEntities.GetContext().Medical_insurance.ToList();
            lbMed.ItemsSource = MediCarePlusEntities.GetContext().Medical_insurance.ToList();
            dGridClients.ItemsSource = MediCarePlusEntities.GetContext().Clients.ToList();
            tmStart.SelectedDate = DateTime.Now;
            _currentPaymentsUser.date_start = DateTime.Now;
            DataContext = _currentPaymentsUser;

        }
       

        
            private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string connectionString = $"Data Source = {MainWindow.serverName}\\SQLEXPRESS; Initial Catalog = MediCarePlus; Integrated Security = True";
                string query = "INSERT INTO Contracts (client_id, medical_insurance_id, date_start, date_end) VALUES (@client_id, @medical_insurance_id, @date_start, @date_end)";

                
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@client_id", cbIdClient.Text);
                    command.Parameters.AddWithValue("@medical_insurance_id", cbMedical.Text);
                    command.Parameters.AddWithValue("@date_start", tmStart.Text);
                    command.Parameters.AddWithValue("@date_end", tmEnd.Text); 
                    command.ExecuteNonQuery();
                    MediCarePlusEntities.GetContext().SaveChanges();

                }
                Manager.MainFrame.Navigate(new ContractPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ОШИБКA", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ContractPage());
        }
        private void tbSearh_TextChanged(object sender, TextChangedEventArgs e)
        {
            var currentAgents = MediCarePlusEntities.GetContext().Clients.ToList();
            currentAgents = currentAgents.Where(p => p.name.ToLower().Contains(tbSearh.Text.ToLower()) ||
            p.surname.ToLower().Contains(tbSearh.Text.ToLower()) ||
            p.patronymic.ToLower().Contains(tbSearh.Text.ToLower()) ||
            p.id.ToString().Contains(tbSearh.Text.ToLower())).ToList();
            dGridClients.ItemsSource = currentAgents;
        }

        private void lbMed_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Обновляем значение в ComboBox при выборе элемента в ListBox
            if (lbMed.SelectedIndex != -1)
            {
                cbMedical.Text = lbMed.SelectedItem.ToString();
            }
        }
    }
}
