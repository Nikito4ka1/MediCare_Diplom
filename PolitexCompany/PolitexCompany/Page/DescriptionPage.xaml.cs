using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Office.Interop.Word;
using ScottPlot.Drawing.Colormaps;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using Document = iTextSharp.text.Document;
using MessageBox = System.Windows.MessageBox;
using Paragraph = iTextSharp.text.Paragraph;

namespace PolitexCompany.Page
{
    /// <summary>
    /// Логика взаимодействия для DescriptionPage.xaml
    /// </summary>
    public partial class DescriptionPage 
    {
        public DescriptionPage()
        {
            InitializeComponent();
            lvComing.ItemsSource = MediCarePlusEntities.GetContext().Medical_insurance.ToList();

        }

        
        private void tbSearh_TextChanged(object sender, TextChangedEventArgs e)
        {
            var currentAgents = MediCarePlusEntities.GetContext().Medical_insurance.ToList();
            currentAgents = currentAgents.Where(p => p.name.ToLower().Contains(tbSearh.Text.ToLower()) ||
            p.description.ToLower().Contains(tbSearh.Text.ToLower()) ||
            p.price.ToString().Contains(tbSearh.Text.ToLower())).ToList();
            lvComing.ItemsSource = currentAgents;
        }
    }
}
