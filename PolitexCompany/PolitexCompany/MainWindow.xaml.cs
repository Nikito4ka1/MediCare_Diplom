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

namespace PolitexCompany
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static public string serverName = Environment.MachineName;
        public static MainWindow Window;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void Minimazed_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                var currentUser = AppData.DB.Users.FirstOrDefault(c => c.login == tbLogin.Text && c.password == tbPassword.Text);
                if (currentUser == null)
                {
                    throw new Exception("Пользователь не найден");
                }
                if (currentUser != null)
                {
                    MedWindow medWindow = new MedWindow();
                    medWindow.Show();
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ОШИБКA", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }     
        
    }
}
