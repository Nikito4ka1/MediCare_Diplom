using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PolitexCompany.Page
{
    /// <summary>
    /// Логика взаимодействия для AddClientPage.xaml
    /// </summary>
    public partial class AddClientPage
    {
        public AddClientPage()
        {
            InitializeComponent();
        }
        private void btnCave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string connectionString = $"Data Source = { MainWindow.serverName }\\SQLEXPRESS; Initial Catalog = MediCarePlus; Integrated Security = True";
                string query = "INSERT INTO Clients (name, surname, patronymic, address, phone, email) VALUES (@name, @surname, @patronymic, @address, @phone, @email)";

                // string query3 = "INSERT INTO Location (Num_room) VALUES (@Num_room)";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@name", tbName.Text);
                    command.Parameters.AddWithValue("@surname", tbSurname.Text);
                    command.Parameters.AddWithValue("@patronymic", tbPatronymic.Text);
                    command.Parameters.AddWithValue("@address", tbAddress.Text);
                    command.Parameters.AddWithValue("@phone", tbPhone.Text);
                    command.Parameters.AddWithValue("@email", tbEmail.Text);
                    command.ExecuteNonQuery();

                }
                Manager.MainFrame.Navigate(new ClientPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ОШИБКA", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ClientPage());
        }
    }
}
