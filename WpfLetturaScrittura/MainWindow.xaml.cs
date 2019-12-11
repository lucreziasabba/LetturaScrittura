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
using System.IO;

namespace WpfLetturaScrittura
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

        Random random = new Random();

        private void Genera_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int n = int.Parse(txtN.Text);
                if (n < 0)
                    MessageBox.Show("Il numero è fuori dai limiti");
                int[] array = new int[n];
                for (int i = 0; i < array.Length; i++)
                    array[i] = random.Next(1, 100);
                lblArray.Content = "[";
                for (int i = 0; i < array.Length; i++)
                {
                    lblArray.Content += $"{array[i]}";
                    if (i < array.Length - 1)
                        lblArray.Content += ",";
                }
                lblArray.Content += "]";
                string file = "stato.txt";
                StreamWriter sw = new StreamWriter(file);
                for (int i = 0; i < array.Length; i++)
                {
                    sw.WriteLine(array[i] + " ");
                }
                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
