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

namespace TothRegina_beadandó
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Szamla> szamlak = new List<Szamla>();
        public MainWindow()
        {
            Szamla szamla1 = new Szamla(2500,"Beta");
            Szamla szamla2 = new Szamla(3500, "Alfa");
            szamlak.Add(szamla1);
            szamlak.Add(szamla2);
            //Szamla1Egyen.Text = Convert.ToString(szamlak[0].Egyenleg);
            //Szamla2Egyen.Text = Convert.ToString(szamlak[1].Egyenleg);


            InitializeComponent();
        }

        private void Feltolt1_Click(object sender, RoutedEventArgs e)
        {
            szamlak[0].Egyenlegno(Convert.ToInt32(Bevitel1.Text));
            Szamla1Egyen.Text = Convert.ToString( szamlak[0].Egyenleg);
        }

        private void Utalas1_Click(object sender, RoutedEventArgs e)
        {
            szamlak[0].Egyenlegcsokk(Convert.ToInt32(Bevitel1.Text));
            szamlak[1].Egyenlegno(Convert.ToInt32(Bevitel1.Text));
            Szamla1Egyen.Text = Convert.ToString(szamlak[0].Egyenleg);
            Szamla2Egyen.Text = Convert.ToString(szamlak[1].Egyenleg);
        }

        private void Kivet1_Click(object sender, RoutedEventArgs e)
        {
            szamlak[0].Egyenlegcsokk(Convert.ToInt32(Bevitel1.Text));
            Szamla1Egyen.Text = Convert.ToString(szamlak[0].Egyenleg);
        }

        private void NevValtas1_Click(object sender, RoutedEventArgs e)
        {
            szamlak[0].tulaj = Bevitel1.Text;
            Szamla1Tul.Text = szamlak[0].tulaj;
        }
        private void Feltolt2_Click(object sender, RoutedEventArgs e)
        {
            szamlak[1].Egyenlegno(Convert.ToInt32(Bevitel2.Text));
            Szamla2Egyen.Text = Convert.ToString(szamlak[1].Egyenleg);
        }

        private void Utalas2_Click(object sender, RoutedEventArgs e)
        {
            szamlak[1].Egyenlegcsokk(Convert.ToInt32(Bevitel1.Text));
            szamlak[0].Egyenlegno(Convert.ToInt32(Bevitel1.Text));
            Szamla1Egyen.Text = Convert.ToString(szamlak[0].Egyenleg);
            Szamla2Egyen.Text = Convert.ToString(szamlak[1].Egyenleg);
        }

        private void Kivet2_Click(object sender, RoutedEventArgs e)
        {
            szamlak[1].Egyenlegcsokk(Convert.ToInt32(Bevitel2.Text));
            Szamla2Egyen.Text = Convert.ToString(szamlak[1].Egyenleg);
        }

        private void NevValtas2_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
