using System;
using System.Collections.Generic;
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


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Tanulo> adatok;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            adatok = new List<Tanulo>();

            foreach (var item in File.ReadAllLines("naplo.txt", Encoding.UTF8))
            {
                adatok.Add(new Tanulo(item));
            }

            dgLista.ItemsSource = adatok;
        }

        private void btnOsztalyletszam_Click(object sender, RoutedEventArgs e)
        {
            int emberek = 0;
            string osztaly = txtOsztalyKereso.Text;

            foreach (var item in adatok)
            {
                if (item.Osztaly == osztaly)
                {
                    emberek++;
                }
            }
            lbOsztalyletszam.Content = emberek;
        }


        private void btnKettoAlatt_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter sw = new StreamWriter("figyelmeztetés.txt");
            foreach (var item in adatok)
            {
                if (item.Atlag < 2)
                {
                    string paste = $"{item.Nev} {item.Atlag}";
                    sw.WriteLine(paste);
                }
            }
            sw.Close();
            MessageBox.Show("Sikeres művelet!");
        }

        private void btnIskolaAtlag_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
