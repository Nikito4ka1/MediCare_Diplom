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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PolitexCompany
{
    /// <summary>
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage 
    {
        private Clients _currentClients = new Clients();

        public ClientPage()
        {
            InitializeComponent();
            DataContext = _currentClients;
            dGridClients.ItemsSource = MediCarePlusEntities.GetContext().Clients.ToList();
        }
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Page.AddClientPage());
        }

        

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Page.RedactPage((sender as Button).DataContext as Clients));
        }

        private void btnDeleted_Click(object sender, RoutedEventArgs e)
        {
            var HousesForRemoving = dGridClients.SelectedItems.Cast<Clients>().ToList();

            try
            {
                MediCarePlusEntities.GetContext().Clients.RemoveRange(HousesForRemoving);
                MediCarePlusEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные удалены!");
                dGridClients.ItemsSource = MediCarePlusEntities.GetContext().Clients.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
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
    }
}
