using System.Windows;
using FynbusProject;
using System;

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

            button_ExportCsv.IsEnabled = false;
            button_ExportPdf.IsEnabled = false;
            button_CalculateWinners.IsEnabled = false;
            button_Clear.IsEnabled = false;
            button_Import.IsEnabled = false;
        }

        private void button_Clear_Click(object sender, RoutedEventArgs e)
        {
            textBox_BasicData.Text = string.Empty;
            textBox_OfferData.Text = string.Empty;
            textBox_Routes.Text = string.Empty;
            button_Clear.IsEnabled = false;
            button_CalculateWinners.IsEnabled = false;
            button_Import.IsEnabled = false;
            bool dataCleared = CSVImport.Instance.ClearData();

            if (dataCleared)
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
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            // Set filter for file extension and default file extension
            dlg.DefaultExt = ".csv";
            dlg.Filter = "CSV file (.csv)|*.csv";

            // Display OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox
            if (result == true)
            {
                // Open document
                string filePathContractor = dlg.FileName;
                textBox_BasicData.Text = filePathContractor;
            }
        }

        private void button_ChooseOfferData_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            // Set filter for file extension and default file extension
            dlg.DefaultExt = ".csv";
            dlg.Filter = "CSV file (.csv)|*.csv";

            // Display OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox
            if (result == true)
            {
                // Open document
                string filePathOffer = dlg.FileName;
                textBox_OfferData.Text = filePathOffer;
            }
        }

        private void button_ChooseRoutes_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            // Set filter for file extension and default file extension
            dlg.DefaultExt = ".csv";
            dlg.Filter = "CSV file (.csv)|*.csv";

            // Display OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox
            if (result == true)
            {
                // Open document
                string filePathRoute = dlg.FileName;
                textBox_Routes.Text = filePathRoute;
                button_Import.IsEnabled = true;

            }
        }

        private void button_Import_Click(object sender, RoutedEventArgs e)
        {
            string filePathRoute = textBox_Routes.Text;
            bool importSucessfullyRoutes = CSVImport.Instance.Import(filePathRoute, fileType.ROUTES);

            string filePathContractor = textBox_BasicData.Text;
            bool importSucessfullyContractors = CSVImport.Instance.Import(filePathContractor, fileType.CONTRACTORS);

            string filePathOffer = textBox_OfferData.Text;
            bool importSucessfullyOffers = CSVImport.Instance.Import(filePathOffer, fileType.OFFERS);

            if (importSucessfullyContractors == true && importSucessfullyOffers == true && importSucessfullyRoutes == true)
            {
                MessageBox.Show("Data is imported sucessfuly!");
                button_CalculateWinners.IsEnabled = true;
                button_Clear.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Oops! Something went wrong importing, please try again");
            }

        }
    }
}
