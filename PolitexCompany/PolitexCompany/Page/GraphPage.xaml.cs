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
using ScottPlot;
using System.Drawing.Design;
using System.Drawing;
using System.Data.Entity.Infrastructure;
using System.Net.NetworkInformation;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Markup;

namespace PolitexCompany.Page
{
    /// <summary>
    /// Логика взаимодействия для GraphPage.xaml
    /// </summary>
    public partial class GraphPage 
    {
        double[] pricesArray;
        DateTime[] datesArray;

        public GraphPage()
        {
            InitializeComponent();
            var plt = new Plot(600, 400);

            double[] values = { 26, 20, 23, 7, 16 };
            double[] positions = { 0, 1, 2, 3, 4 };
            string[] labels = { "PHP", "JS", "C++", "GO", "VB" };
            plt.AddBar(values, positions);
            plt.XTicks(positions, labels);
            plt.SetAxisLimits(yMin: 0);

            plt.SaveFig("bar_labels.png");
            Graph.Refresh();
        }

        
        private void PlotGraph()
        {
            Plot plt = new Plot();
            double[] values = pricesArray;
            double[] positions = new double[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                positions[i] = i;
            }

            string[] labels = new string[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                labels[i] = datesArray[i].ToString("MMMM");
            }

            Graph.Plot.Clear();
            Graph.Plot.AddBar(values, positions);
            Graph.Plot.XTicks(positions, labels);
            Graph.Plot.SetAxisLimits(yMin: 0);
            Graph.Refresh();
        }
       
        public void ArrayFillByYear(int year)
        {
            List<double> pricesList = new List<double>();
            List<DateTime> datesList = new List<DateTime>();

            string connectionString = $"Data Source = {MainWindow.serverName}\\SQLEXPRESS; Initial Catalog = MediCarePlus; Integrated Security = True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlQuery = $@"SELECT FORMAT(date_start, 'yyyy-MM') AS month_year, SUM(price) AS total_price FROM Contracts JOIN Medical_insurance ON medical_insurance.id = Contracts.medical_insurance_id WHERE YEAR(date_start) = {year} GROUP BY FORMAT(date_start, 'yyyy-MM') ORDER BY month_year;";
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (double.TryParse(reader["total_price"].ToString(), out double sum) && DateTime.TryParse(reader["month_year"].ToString(), out DateTime date))
                        {
                            pricesList.Add(sum);
                            datesList.Add(date);
                        }
                    }
                }

                datesArray = datesList.ToArray();
                pricesArray = pricesList.ToArray();
            }
        }

        private void YearComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (YearComboBox.SelectedItem != null)
            {
                string selectedYear = ((ComboBoxItem)YearComboBox.SelectedItem).Content.ToString();
                int year = int.Parse(selectedYear);
                ArrayFillByYear(year);
                PlotGraph();
            }
        }
    }
}
    

