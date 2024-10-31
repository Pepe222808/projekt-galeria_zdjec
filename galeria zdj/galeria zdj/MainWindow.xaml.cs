using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace galeria_zdj
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

        private int id = 1;

        private void change_photo()
        {
            string adres= "/img/kot"+id+".jpg";
            Uri adres_obrazka = new Uri(adres, UriKind.Relative);
            zdjecia.Source = new BitmapImage(adres_obrazka);
            debug.Content = adres;
        }

        private void Prev_Click(object sender, RoutedEventArgs e)
        {
            id = id - 1;
            if (id == 0) 
            {
                id = 4;
            }
            change_photo();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            id = id + 1;
            if (id == 5)
            {
                id = 1;
            }
            change_photo();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(input.Text != "") 
            {
                id = Int32.Parse(input.Text);
                if (id > 0 && id < 5)
                {
                    change_photo();
                }
            }
        }

        private void cb_tlo_Checked(object sender, RoutedEventArgs e)
        {
            zmiana_tla("#FF1565C0", true); 
        }

        private void cb_tlo_Unchecked(object sender, RoutedEventArgs e)
        {
            zmiana_tla("#FF00796B", false); 
        }

        private void zmiana_tla(string color, bool state)
        {
            if (cb_tlo.IsChecked == state)
            {
                Color colorBkg = (Color)ColorConverter.ConvertFromString(color);
                grid.Background = new SolidColorBrush(colorBkg);
            }
        }
        private void walidacja_liczb(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
