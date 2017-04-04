using System.Windows;
using FynbusProject;
using Microsoft.Win32;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Clear_Click(object sender, RoutedEventArgs e)
        {

            textBox_BasicData.Text = string.Empty;
            textBox_OfferData.Text = string.Empty;
            textBox_Routes.Text = string.Empty;
            button_ExportCsv.IsEnabled = false;
            button_ExportPdf.IsEnabled = false;
            bool dataCleared = CSVImport.Instance.ClearData();

            if(dataCleared)
            {
                MessageBox.Show("Data and interface cleared sucessfuly!");
            }
            else
            {
                MessageBox.Show("Oops! Something went wrong clearing the data, please try again");
            }
        }

        private void button_ChooseContractorData_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = true;
            ofd.Multiselect = false;
            ofd.AddExtension = true;
            ofd.ShowDialog();
            textBox_BasicData.Text = ofd.FileName;
        }

        private void button_ChooseOfferData_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = true;
            ofd.Multiselect = false;
            ofd.AddExtension = true;
            ofd.ShowDialog();
            textBox_OfferData.Text = ofd.FileName;
        }

        private void button_ChooseRoutes_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = true;
            ofd.Multiselect = false;
            ofd.AddExtension = true;
            ofd.ShowDialog();
            textBox_Routes.Text = ofd.FileName;
        }

        private void button_Import_Click(object sender, RoutedEventArgs e)
        {
            CSVImport.Instance.Import(textBox_Routes.Text, fileType.ROUTES);
            CSVImport.Instance.Import(textBox_BasicData.Text, fileType.CONTRACTORS);
            CSVImport.Instance.Import(textBox_OfferData.Text, fileType.OFFERS);
        }

        private void button_ExportPdf_Click(object sender, RoutedEventArgs e)
        {
            CalculateWinner cw = new CalculateWinner();
            cw.GetWinners();

            Export exp = new Export(cw,4);
            exp.ExportToPDF();
        }
    }
}
