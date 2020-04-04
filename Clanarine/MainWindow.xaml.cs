using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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

namespace Clanarine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Osoba> Imenik = new ObservableCollection<Osoba>();
        public MainWindow()
        {
            InitializeComponent();
            citaj();
            DateTime nultoVreme = new DateTime(0001, 01, 01);

            dg1.ItemsSource = Imenik.Where(Osoba => Osoba.Clanarina == nultoVreme).ToList();

            dg2.ItemsSource = Imenik.Where(Osoba => Osoba.Clanarina != nultoVreme).ToList();
        }
        public void citaj()
        {
            BinaryFormatter bf = new BinaryFormatter();
            if (File.Exists("Imenik"))
            {
                using (FileStream FS = new FileStream("Imenik", FileMode.Open, FileAccess.Read))
                {
                                  Imenik = (bf.Deserialize(FS) as ObservableCollection<Osoba>);
                }
                
            }
        }


        private void UnosUImenik(object sender, RoutedEventArgs e)
        {
            Unos unosclanova = new Unos();
            unosclanova.DataContext = new Osoba();
            unosclanova.Owner = this;
            unosclanova.ShowDialog();

            if (unosclanova.DialogResult == true)
            {
            Imenik.Add(unosclanova.DataContext as Osoba);

                DateTime nultoVreme = new DateTime(0001, 01, 01);
                dg1.ItemsSource = Imenik.Where(Osoba => Osoba.Clanarina == nultoVreme).ToList();

            }



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            if(dg1.SelectedItem != null)
            {
                DateTime sada = DateTime.Now;

                Akt dodavanje = new Akt();
                dodavanje.Owner = this;
                dodavanje.ShowDialog();

                int a = int.Parse(dodavanje.TB1.Text);
                (dg1.SelectedItem as Osoba).Clanarina = sada.AddDays(a);

                refresh();
            }

        }

        private void refresh()
        {
            DateTime nultoVreme = new DateTime(0001, 01, 01);
            dg1.ItemsSource = Imenik.Where(Osoba => Osoba.Clanarina == nultoVreme).ToList();
            dg2.ItemsSource = Imenik.Where(Osoba => Osoba.Clanarina != nultoVreme).ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(dg1.SelectedItem != null)
            {
                Imenik.Remove(dg1.SelectedItem as Osoba);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if(dg2.SelectedItem != null)
            {
                DateTime trenutno = (dg2.SelectedItem as Osoba).Clanarina;
                Akt povecaj = new Akt();
                povecaj.Owner = this;
                povecaj.ShowDialog();
                int a = int.Parse(povecaj.TB1.Text);

                (dg2.SelectedItem as Osoba).Clanarina = trenutno.AddDays(a);
                refresh();
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (dg2.SelectedItem != null)
            {
                (dg2.SelectedItem as Osoba).Clanarina = new DateTime(0001, 01, 01);
                refresh();
            }
        }

        private void zatvaranje(object sender, System.ComponentModel.CancelEventArgs e)
        {
            BinaryFormatter BF = new BinaryFormatter();
            using (FileStream FS = new FileStream("Imenik", FileMode.Create, FileAccess.Write))
            {
                BF.Serialize(FS, Imenik);
            }
        }
    }
}
