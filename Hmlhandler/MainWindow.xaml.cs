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
using System.Xml;
using System.IO;

namespace Xmlhandler
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> FileNames = new List<string>();
        private void GetFile()
        {

            IEnumerable<string> allfiles = Directory.EnumerateFiles("../../../Resources/", "*.xml");
            foreach (string filename in allfiles)
                FileNames.Add(filename.Remove(filename.Length - 4).Remove(0, 19));

        }
        public MainWindow()
        {
            InitializeComponent();
            GetFile();
            List<Files> precis = new List<Files>();
            foreach (string file in FileNames)
                precis.Add(new Files { filename = file });

            Data.ItemsSource = precis;
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            Files path = Data.SelectedItem as Files;
            Precis window = new Precis(path.filename);
            window.Show();

        }
    }
}
