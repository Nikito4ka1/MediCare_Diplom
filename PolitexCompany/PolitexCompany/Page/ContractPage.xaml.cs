using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace PolitexCompany.Page
{
    /// <summary>
    /// Логика взаимодействия для ContractPage.xaml
    /// </summary>
    public partial class ContractPage
    {

        private static Medical_insurance medical_insurance;
        private static List<Contracts> contracts;

        public ContractPage()
        {

            InitializeComponent();
            dGridContract.ItemsSource = MediCarePlusEntities.GetContext().Contracts.ToList();
            cbMedical_insurance.ItemsSource = MediCarePlusEntities.GetContext().Medical_insurance.ToList();
            cbMedical_insurance.SelectedIndex = 0;
            contracts = MediCarePlusEntities.GetContext().Contracts.ToList();
            dGridContract.ItemsSource = contracts;
            DpkStart.SelectedDate = contracts.Min(p => p.date_start);
            DpkEnd.SelectedDate = contracts.Max(p => p.date_end);

        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Page.AddContractPage());
        }

        private void btnDeleted_Click(object sender, RoutedEventArgs e)
        {
            var HousesForRemoving = dGridContract.SelectedItems.Cast<Contracts>().ToList();

            try
            {
                MediCarePlusEntities.GetContext().Contracts.RemoveRange(HousesForRemoving);
                MediCarePlusEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные удалены!");
                dGridContract.ItemsSource = MediCarePlusEntities.GetContext().Contracts.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BtnFilter_Click(object sender, RoutedEventArgs e)
        {

            contracts = MediCarePlusEntities.GetContext().Contracts.ToList(); // Получаем все контракты

            if (cbMedical_insurance.SelectedIndex >= 0) // Проверяем, выбран ли элемент (не первый пункт "All")
            {
                medical_insurance = cbMedical_insurance.SelectedItem as Medical_insurance; // Присваиваем выбранное медицинское страхование переменной
                if (medical_insurance != null)
                {
                    contracts = contracts.Where(p => p.medical_insurance_id == medical_insurance.id && // Фильтруем контракты
                    p.date_start >= DpkStart.SelectedDate && p.date_end <= DpkEnd.SelectedDate).ToList();

                }

            }
            if (DpkStart != null) // Если выбрана сортировка по времени
            {
                contracts = contracts.Where(p => p.date_start >= DpkStart.SelectedDate && p.date_end <= DpkEnd.SelectedDate).ToList(); // Фильтруем контракты по времени
            }
            dGridContract.ItemsSource = contracts;

        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            cbMedical_insurance.SelectedIndex = 0;
            contracts = MediCarePlusEntities.GetContext().Contracts.ToList();
            dGridContract.ItemsSource = contracts;
            DpkStart.SelectedDate = contracts.Min(p => p.date_start);
            DpkEnd.SelectedDate = contracts.Max(p => p.date_end);
        }

        private void tbSearh_TextChanged(object sender, TextChangedEventArgs e)
        {
            var currentAgents = MediCarePlusEntities.GetContext().Contracts.ToList();
            currentAgents = currentAgents.Where(p => p.Clients.name.ToLower().Contains(tbSearh.Text.ToLower()) ||
            p.Clients.surname.ToLower().Contains(tbSearh.Text.ToLower()) ||
            p.Clients.patronymic.ToLower().Contains(tbSearh.Text.ToLower()) ||
            p.Clients.id.ToString().Contains(tbSearh.Text.ToLower())).ToList();
            dGridContract.ItemsSource = currentAgents;
        }

        private void btnCreatePDF_Click(object sender, RoutedEventArgs e)
        {
            // Получаем выбранный элемент из dGridContract
            Contracts selectedContract = dGridContract.SelectedItem as Contracts;

            if (selectedContract != null)
            {
                // Теперь у нас есть выбранный контракт, и мы можем получить доступ к его свойствам
                string name = selectedContract.Clients.name;
                string surname = selectedContract.Clients.surname;
                string patronymic = selectedContract.Clients.patronymic;
                string medical_insurance = selectedContract.Medical_insurance.name;
                // Далее можно использовать полученные значения
                try
                {

                    // Получаем путь к корневому каталогу проекта
                    string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

                    // Формируем пути к файлам
                    string imagePath = System.IO.Path.Combine(projectDirectory, "Res", "med.png"); // Путь к логотипу
                    string pdfPath = System.IO.Path.Combine(projectDirectory, "Doc", $"{surname}_{name}_{patronymic}_{medical_insurance}_Договор.pdf"); // Путь сохранения PDF-документа

                    // Создаем шрифт
                    BaseFont baseFont = BaseFont.CreateFont("c:\\windows\\fonts\\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);

                    // Создаем экземпляр PDF-документа
                    var pdfDoc = new Document(PageSize.LETTER, 40f, 40f, 60f, 60f);//задаем размер страницы документа
                    PdfWriter.GetInstance(pdfDoc, new FileStream(pdfPath, FileMode.OpenOrCreate));//создаем экземпляр pdf документа
                    pdfDoc.Open();//открываем его

                    iTextSharp.text.Paragraph leadparagraph = new iTextSharp.text.Paragraph($"{medical_insurance}\r\n", font);
                    leadparagraph.Alignment = Element.ALIGN_CENTER;
                    pdfDoc.Add(leadparagraph);
                    iTextSharp.text.Paragraph leadparagraph1 = new iTextSharp.text.Paragraph("\r\n\r\n Стороны \r\n", font);
                    leadparagraph1.Alignment = Element.ALIGN_CENTER;
                    pdfDoc.Add(leadparagraph1);
                    iTextSharp.text.Paragraph leadparagraph2 = new iTextSharp.text.Paragraph($"\r\n\r\n     Страховая компания Надежный Страховщик, именуемая в дальнейшем Страховщик, с одной стороны, и г-н/г-жа {surname} {name} {patronymic}, именуемый(ая) в дальнейшем Страхователь, с другой стороны.\r\n", font);
                    leadparagraph2.Alignment = Element.ALIGN_LEFT;
                    pdfDoc.Add(leadparagraph2);
                    iTextSharp.text.Paragraph leadparagraph3 = new iTextSharp.text.Paragraph("\r\n\r\n Предмет договора\r\n", font);
                    leadparagraph3.Alignment = Element.ALIGN_CENTER;
                    pdfDoc.Add(leadparagraph3);
                    iTextSharp.text.Paragraph leadparagraph4 = new iTextSharp.text.Paragraph("\r\n\r\n      Страховщик обязуется предоставить медицинское страхование Страхователю в соответствии с условиями настоящего договора. Медицинское страхование предоставляется на случай несчастных случаев, болезней, операций, а также других медицинских расходов, указанных в полисе страхования.\r\n", font);
                    pdfDoc.Add(leadparagraph4);
                    iTextSharp.text.Paragraph leadparagraph5 = new iTextSharp.text.Paragraph("\r\n\r\n Обязанности страхователя\r\n", font);
                    leadparagraph5.Alignment = Element.ALIGN_CENTER;
                    pdfDoc.Add(leadparagraph5);
                    iTextSharp.text.Paragraph leadparagraph6 = new iTextSharp.text.Paragraph("\r\n\r\n      Своевременно уведомлять Страховщика о случаях, требующих медицинской помощи.\r\n Предоставить все необходимые документы и сведения, необходимые для оформления страхового случая.\r\n", font);
                    leadparagraph6.Alignment = Element.ALIGN_LEFT;
                    pdfDoc.Add(leadparagraph6);
                    iTextSharp.text.Paragraph leadparagraph7 = new iTextSharp.text.Paragraph("      Все споры и разногласия, возникающие между сторонами по настоящему договору, разрешаются путем переговоров.\r\n  Изменения и дополнения к настоящему договору действительны только в письменной форме и подписываются обеими сторонами.\r\n\r\n ", font);
                    leadparagraph7.Alignment = Element.ALIGN_LEFT;
                    pdfDoc.Add(leadparagraph7);
                    iTextSharp.text.Paragraph leadparagraph8 = new iTextSharp.text.Paragraph("\r\n Обязанности страховщика\r\n", font);
                    leadparagraph8.Alignment = Element.ALIGN_CENTER;
                    pdfDoc.Add(leadparagraph8);
                    iTextSharp.text.Paragraph leadparagraph9 = new iTextSharp.text.Paragraph("\r\n\r\n      Оплатить медицинские услуги, связанные с лечением и реабилитацией Страхователя в случае возникновения страхового случая.\r\nПредоставить консультации и информацию о медицинских услугах, доступных для Страхователя.\r\n", font);
                    leadparagraph9.Alignment = Element.ALIGN_LEFT;
                    pdfDoc.Add(leadparagraph9);
                    iTextSharp.text.Paragraph leadparagraph10 = new iTextSharp.text.Paragraph("\r\n\r\n Страхователь(подпись и дата):_________________________\r\n", font);
                    leadparagraph8.Alignment = Element.ALIGN_LEFT;
                    pdfDoc.Add(leadparagraph10);
                    iTextSharp.text.Paragraph leadparagraph11 = new iTextSharp.text.Paragraph("\r\n\r\n Страховая компания(подпись и дата):______________________\r\n", font);
                    leadparagraph11.Alignment = Element.ALIGN_LEFT;
                    pdfDoc.Add(leadparagraph11);
                    // Создание объекта изображения
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(imagePath);

                    // Масштабирование изображения по размеру страницы
                    image.ScaleToFit(pdfDoc.PageSize.Width / 2, pdfDoc.PageSize.Height / 2);
                    image.Alignment = 1;
                    // Добавление изображения в документ
                    pdfDoc.Add(image);
                    //Создание пробела
                    var spacer = new iTextSharp.text.Paragraph("")
                    {
                        SpacingBefore = 10f,
                        SpacingAfter = 10f,
                    };
                    pdfDoc.Add(spacer);


                    pdfDoc.Close();
                    MessageBox.Show("Договор сохранен");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void btnCheckPDF_Click(object sender, RoutedEventArgs e)
        {
            Contracts selectedContract = dGridContract.SelectedItem as Contracts;

            if (selectedContract != null)
            {
                // Теперь у нас есть выбранный контракт, и мы можем получить доступ к его свойствам
                string name = selectedContract.Clients.name;
                string surname = selectedContract.Clients.surname;
                string patronymic = selectedContract.Clients.patronymic;
                string medical_insurance = selectedContract.Medical_insurance.name;
                decimal price = selectedContract.Medical_insurance.price;
                DateTime dateTime = DateTime.Now;
                // Далее можно использовать полученные значения
                try
                {

                    // Получаем путь к корневому каталогу проекта
                    string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                    // Формируем пути к файлам
                    string imagePath = System.IO.Path.Combine(projectDirectory, "Res", "med.png"); // Путь к логотипу
                    string pdfPath = System.IO.Path.Combine(projectDirectory, "Check", $"{surname}_{name}_{patronymic}_{medical_insurance}_Чек.pdf"); // Путь сохранения PDF-документа
                    // Создаем шрифт
                    BaseFont baseFont = BaseFont.CreateFont("c:\\windows\\fonts\\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);
                    // Создаем экземпляр PDF-документа
                    var pdfDoc = new Document(PageSize.LETTER, 40f, 40f, 60f, 60f);//задаем размер страницы документа
                    PdfWriter.GetInstance(pdfDoc, new FileStream(pdfPath, FileMode.OpenOrCreate));//создаем экземпляр pdf документа
                    pdfDoc.Open();//открываем его
                    iTextSharp.text.Paragraph leadparagraph = new iTextSharp.text.Paragraph("Чек\r\n\r\n\r\n", font);
                    leadparagraph.Alignment = Element.ALIGN_CENTER;
                    pdfDoc.Add(leadparagraph);
                    iTextSharp.text.Paragraph leadparagraph1 = new iTextSharp.text.Paragraph($"{medical_insurance}\r\n", font);
                    leadparagraph1.Alignment = Element.ALIGN_LEFT;
                    pdfDoc.Add(leadparagraph1);
                    iTextSharp.text.Paragraph leadparagraph2 = new iTextSharp.text.Paragraph($"\r\n\r\nСтраховая компания MediCarePlus, выписывает чек {surname} {name} {patronymic}.\r\n", font);
                    leadparagraph2.Alignment = Element.ALIGN_LEFT;
                    pdfDoc.Add(leadparagraph2);
                    iTextSharp.text.Paragraph leadparagraph3 = new iTextSharp.text.Paragraph($"\r\n\r\nСумма: {price}\r\n", font);
                    leadparagraph3.Alignment = Element.ALIGN_LEFT;
                    pdfDoc.Add(leadparagraph3);
                    iTextSharp.text.Paragraph leadparagraph4 = new iTextSharp.text.Paragraph($"\r\n\r\nДата: {dateTime}\r\n", font);
                    leadparagraph3.Alignment = Element.ALIGN_LEFT;
                    pdfDoc.Add(leadparagraph4);

                    // Создание объекта изображения
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(imagePath);

                    // Масштабирование изображения по размеру страницы
                    image.ScaleToFit(pdfDoc.PageSize.Width / 2, pdfDoc.PageSize.Height / 2);
                    image.Alignment = 1;
                    // Добавление изображения в документ
                    pdfDoc.Add(image);
                    //Создание пробела
                    var spacer = new iTextSharp.text.Paragraph("")
                    {
                        SpacingBefore = 10f,
                        SpacingAfter = 10f,
                    };
                    pdfDoc.Add(spacer);


                    pdfDoc.Close();
                    MessageBox.Show("Чек сохранен");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
