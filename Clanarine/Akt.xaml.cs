using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Clanarine
{
    /// <summary>
    /// Interaction logic for Akt.xaml
    /// </summary>
    public partial class Akt : Window
    {
        public Akt()
        {
            InitializeComponent();
        }

        public void Provera(object sender, TextCompositionEventArgs e)
        {
            Regex reg = new Regex("[^0-9]+");
            e.Handled = reg.IsMatch(e.Text);
        }

        private void Ok(object sender, RoutedEventArgs e)
        {
            if(!(string.IsNullOrEmpty(TB1.Text) && string.IsNullOrWhiteSpace(TB1.Text)))
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Unesite validnu vrednost");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TB1.Text = "";
            this.Close();
        }
    }
}
