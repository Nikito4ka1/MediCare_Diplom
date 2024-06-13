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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PolitexCompany.Page
{
    /// <summary>
    /// Логика взаимодействия для RedactPage.xaml
    /// </summary>
    public partial class RedactPage 
    {
        private Clients _currentApp = new Clients();

        public RedactPage(Clients selectedApp)
        {
            InitializeComponent();
            if (selectedApp != null)
                _currentApp = selectedApp;

            DataContext = _currentApp;

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ClientPage());
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MediCarePlusEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
