using PolitexCompany.Page;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using Path = System.IO.Path;

namespace PolitexCompany
{
    /// <summary>
    /// Логика взаимодействия для MedWindow.xaml
    /// </summary>
    public partial class MedWindow : Window
    {
       
        public MedWindow()
        {
            InitializeComponent();

            MainFrame.Navigate(new ContractPage());
            Manager.MainFrame = MainFrame;
        }

        private void BtnClient_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ClientPage());
            Manager.MainFrame = MainFrame; 
        }

        private void BtnContract_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Page.ContractPage());
            Manager.MainFrame = MainFrame; 
        }
 
        private void Minimazed_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
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

        private void Exet_Click(object sender, RoutedEventArgs e)
        {
            MainWindow Window = new MainWindow();
            Window.Show();
            Close();
        }

        private void BackgroundComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            var selectedItem = comboBox.SelectedItem as ComboBoxItem;

            if (selectedItem != null)
            {
                string imagePath = selectedItem.Tag.ToString();
                backgroundImage.Source = new BitmapImage(new Uri($"pack://application:,,,/Res/{imagePath}"));
            }
        }

        private void MaxMin_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }

        private void Description_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Page.DescriptionPage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Page.GraphPage());
        }

        private void Button_Open_Doc(object sender, RoutedEventArgs e)
        {
            string folderPath = @"Doc"; // Указываем путь к папке

            string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName; // Получаем путь к корневому каталогу проекта

            string fullPath = Path.Combine(projectDirectory, folderPath); // Получаем полный путь к папке

            try
            {
                Process.Start(fullPath); // Открываем папку в проводнике
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось открыть папку: " + ex.Message);
            }
        }

        private void BtnCheck_Click(object sender, RoutedEventArgs e)
        {
            string folderPath = @"Check"; // Указываем путь к папке

            string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName; // Получаем путь к корневому каталогу проекта

            string fullPath = Path.Combine(projectDirectory, folderPath); // Получаем полный путь к папке

            try
            {
                Process.Start(fullPath); // Открываем папку в проводнике
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось открыть папку: " + ex.Message);
            }
        }
    }
}