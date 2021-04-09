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
        /// <summary>
        /// Az egyes számla példány
        /// </summary>
        static Szamla szamla1 = new Szamla(2500, "Beta");

        /// <summary>
        /// A kettes számla példány
        /// </summary>
        static Szamla szamla2 = new Szamla(3500, "Alfa");

        /// <summary>
        /// GUI-t rajzol, kiírja az "alapértelmezett" értékeket
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            Szamla1Egyen.Text = Convert.ToString(szamla1.Egyenleg);
            Szamla2Egyen.Text = Convert.ToString(szamla2.Egyenleg);
            Szamla1Tul.Text = Convert.ToString(szamla1.Tulaj);
            Szamla2Tul.Text = Convert.ToString(szamla2.Tulaj);

        }

        /// <summary>
        /// Az első számlához tartozó feltöltő metódus. 
        /// </summary>
        /// <param name="sender">Hívást indító objektum</param>
        /// <param name="e">Az esemény ami bekövetkezett</param>
        /// <remarks>
        /// A bal oldali feltölt gomb lenyomása esetén ellenőrzi az egyes beviteli mező értékét. Ha szöveget vagy negatív értéket tartalmaz akkor hiba üzenetet dob egy új ablakban.
        /// Ha az érték egy pozitív szám akkor növeli a számla egyenlegét.
        /// </remarks>
        private void Feltolt1_Click(object sender, RoutedEventArgs e)
        {
            int osszeg;
            bool szame = Int32.TryParse(Bevitel1.Text, out osszeg);
            if (szame)
            {
                if (Convert.ToInt32(Bevitel1.Text) < 0)   
                {
                    HibaUzenet hiba = new HibaUzenet("Nem adhat meg negatív értéket!");
                    hiba.Show();
                }
                else
                {
                    szamla1.Egyenlegno(osszeg);
                    Szamla1Egyen.Text = Convert.ToString(szamla1.Egyenleg);
                }
            }
            else
            {
                HibaUzenet hiba = new HibaUzenet("Nem számot adott meg!");
                hiba.Show();
            } 
        }

        /// <summary>
        /// Az első számla utalását végző metódus.
        /// </summary>
        /// <param name="sender">Hívást indító objektum</param>
        /// <param name="e">Az esemény ami bekövetkezett</param>
        /// <remarks>
        /// A bal oldali utalás gomb lenyomása esetén ellenőrzi az egyes beviteli mező értékét. Ha szöveget vagy negatív értéket tartalmaz akkor hiba üzenetet dob egy új ablakban.
        /// Ha az érték egy pozitív szám akkor megnézi, hogy elég pénz van-e a számlán és ha igen akkor elvégzi az utalást a két számla között.
        /// </remarks>
        private void Utalas1_Click(object sender, RoutedEventArgs e)
        {
            int osszeg;
            bool szame = Int32.TryParse(Bevitel1.Text, out osszeg);
            if (szame)
            {
                if (Convert.ToInt32(Bevitel1.Text) < 0)
                {
                    HibaUzenet hiba = new HibaUzenet("Nem adhat meg negatív értéket!");
                    hiba.Show();
                }
                else
                {
                    if ((szamla1.Egyenleg - osszeg) < 0)
                    {
                        HibaUzenet hiba = new HibaUzenet("Nincs elég pénz a számláján!\n Adjon meg kisebb összeget!");
                        hiba.Show();
                    }
                    else
                    {
                        szamla1.Egyenlegcsokk(osszeg);
                        szamla2.Egyenlegno(osszeg);
                        Szamla1Egyen.Text = Convert.ToString(szamla1.Egyenleg);
                        Szamla2Egyen.Text = Convert.ToString(szamla2.Egyenleg);
                    }
                }
            }
            else
            {
                HibaUzenet hiba = new HibaUzenet("Nem számot adott meg!");
                hiba.Show();
            }        
        }

        /// <summary>
        /// Az első számla egyenlegét csökkentő metódus.
        /// </summary>
        /// <param name="sender">Hívást indító objektum</param>
        /// <param name="e">Az esemény ami bekövetkezett</param>
        /// <remarks>
        /// A bal oldali kivét gomb lenyomása esetén először ellenőrzi az egyes beviteli mező értékét. Ha a bevitt érték nem szám vagy negatív szám akkor hibaüzenetet dob egy új ablakban. 
        /// Ha az érték egy pozitív szám akkor megnézi, hogy elég pénz van-e a számlán és ha igen akkor növeli a számla egyenlegét a megadott összeggel.
        /// </remarks>
        private void Kivet1_Click(object sender, RoutedEventArgs e)
        {
            int osszeg;
            bool szame = Int32.TryParse(Bevitel1.Text, out osszeg);
            if (szame)
            {
                if (Convert.ToInt32(Bevitel1.Text) < 0)
                {
                    HibaUzenet hiba = new HibaUzenet("Nem adhat meg negatív értéket!");
                    hiba.Show();
                }
                else
                {
                    if ((szamla1.Egyenleg - osszeg) < 0)
                    {
                        HibaUzenet hiba = new HibaUzenet("Nincs elég pénz a számláján!\n Adjon meg kisebb összeget!");
                        hiba.Show();
                    }
                    else
                    {
                        szamla1.Egyenlegcsokk(osszeg);
                        Szamla1Egyen.Text = Convert.ToString(szamla1.Egyenleg);
                    }            
                }
            }
            else
            {
                HibaUzenet hiba = new HibaUzenet("Nem számot adott meg!");
                hiba.Show();
            }
        }

        /// <summary>
        /// Az egyes számla tulajdonosának nevét megváltoztató metódus.
        /// </summary>
        /// <param name="sender">Hívást indító objektum</param>
        /// <param name="e">Az esemény ami bekövetkezett</param>
        /// <remarks>
        /// A bal oldali tulajdonos név váltás gomb lenyomása esetén először ellenőrizzük az egyes beviteli mező értékét.
        /// Ha az érték számot tartalmaz akkor hiba üzenetet dob egy új ablakban, ha pedig helyes akkor beállítja az új nevet.
        /// </remarks>
        private void NevValtas1_Click(object sender, RoutedEventArgs e)
        {
            bool vaneszam= false;
            for (int i = 0; i < Bevitel1.Text.Length; i++)
            {
                if (!char.IsDigit(Bevitel1.Text[i]))
                {
                    vaneszam = false;
                }
                else
                {
                    vaneszam = true;
                    break;
                }
            }
            if (vaneszam)
            {
                HibaUzenet hiba = new HibaUzenet("A tulaj nevében nem lehet szám!");
                hiba.Show();
            }
            else
            {
                szamla1.tulaj = Bevitel1.Text;
                Szamla1Tul.Text = szamla1.tulaj;
            }
            
        }

        /// <summary>
        /// Az második számlához tartozó feltöltő metódus.
        /// </summary>
        /// <param name="sender">Hívást indító objektum</param>
        /// <param name="e">Az esemény ami bekövetkezett</param>
        /// <remarks>
        /// A jobb oldali feltölt gomb lenyomása esetén ellenőrzi a kettes beviteli mező értékét. Ha szöveget vagy negatív értéket tartalmaz akkor hiba üzenetet dob egy új ablakban.
        /// Ha az érték egy pozitív szám akkor növeli a számla egyenlegét.
        /// </remarks>
        private void Feltolt2_Click(object sender, RoutedEventArgs e)
        {
            int osszeg;
            bool szame = Int32.TryParse(Bevitel2.Text, out osszeg);
            if (szame)
            {
                if (Convert.ToInt32(Bevitel2.Text) < 0)
                {
                    HibaUzenet hiba = new HibaUzenet("Nem adhat meg negatív értéket!");
                    hiba.Show();
                }
                else
                {
                    szamla2.Egyenlegno(osszeg);
                    Szamla2Egyen.Text = Convert.ToString(szamla2.Egyenleg);
                }
            }
            else
            {
                HibaUzenet hiba = new HibaUzenet("Nem számot adott meg!");
                hiba.Show();
            }
        }

        /// <summary>
        /// A második számla utalását végző metódus.
        /// </summary>
        /// <param name="sender">Hívást indító objektum</param>
        /// <param name="e">Az esemény ami bekövetkezett</param>
        /// <remarks>
        /// A jobb oldali utalás gomb lenyomása esetén ellenőrzi a kettes beviteli mező értékét. Ha szöveget vagy negatív értéket tartalmaz akkor hiba üzenetet dob egy új ablakban.
        /// Ha az érték egy pozitív szám akkor megnézi, hogy elég pénz van-e a számlán és ha igen akkor elvégzi az utalást a két számla között.
        /// </remarks>
        private void Utalas2_Click(object sender, RoutedEventArgs e)
        {
            int osszeg;
            bool szame = Int32.TryParse(Bevitel2.Text, out osszeg);
            if (szame)
            {
                if (Convert.ToInt32(Bevitel2.Text) < 0)
                {
                    HibaUzenet hiba = new HibaUzenet("Nem adhat meg negatív értéket!");
                    hiba.Show();
                }
                else
                {
                    if ((szamla2.Egyenleg-osszeg)<0)
                    {
                        HibaUzenet hiba = new HibaUzenet("Nincs elég pénz a számláján!\n Adjon meg kisebb összeget!");
                        hiba.Show();
                    }
                    else
                    {
                        szamla2.Egyenlegcsokk(osszeg);
                        szamla1.Egyenlegno(osszeg);
                        Szamla1Egyen.Text = Convert.ToString(szamla1.Egyenleg);
                        Szamla2Egyen.Text = Convert.ToString(szamla2.Egyenleg);
                    }             
                }
            }
            else
            {
                HibaUzenet hiba = new HibaUzenet("Nem számot adott meg!");
                hiba.Show();
            }
        }

        /// <summary>
        /// A második számla egyenlegét csökkentő metódus.
        /// </summary>
        /// <param name="sender">Hívást indító objektum</param>
        /// <param name="e">Az esemény ami bekövetkezett</param>
        /// <remarks>
        /// A jobb oldali kivét gomb lenyomása esetén először ellenőrzi a kettes beviteli mező értékét. Ha a bevitt érték nem szám vagy negatív szám akkor hibaüzenetet dob egy új ablakban. 
        /// Ha az érték egy pozitív szám akkor megnézi, hogy elég pénz van-e a számlán és ha igen akkor növeli a számla egyenlegét a megadott összeggel.
        /// </remarks>
        private void Kivet2_Click(object sender, RoutedEventArgs e)
        {
            int osszeg;
            bool szame = Int32.TryParse(Bevitel2.Text, out osszeg);
            if (szame)
            {
                if (Convert.ToInt32(Bevitel2.Text) < 0)
                {
                    HibaUzenet hiba = new HibaUzenet("Nem adhat meg negatív értéket!");
                    hiba.Show();
                }
                else
                {
                    if ((szamla2.Egyenleg - osszeg) < 0)
                    {
                        HibaUzenet hiba = new HibaUzenet("Nincs elég pénz a számláján!\n Adjon meg kisebb összeget!");
                        hiba.Show();
                    }
                    else
                    {
                        szamla2.Egyenlegcsokk(osszeg);
                        Szamla2Egyen.Text = Convert.ToString(szamla2.Egyenleg);
                    }
                }
            }
            else
            {
                HibaUzenet hiba = new HibaUzenet("Nem számot adott meg!");
                hiba.Show();
            }       
        }

        /// <summary>
        /// A második számla tulajdonosának nevét megváltoztató metódus.
        /// </summary>
        /// <param name="sender">Hívást indító objektum</param>
        /// <param name="e">Az esemény ami bekövetkezett</param>
        /// <remarks>
        /// A jobb oldali tulajdonos név váltás gomb lenyomása esetén először ellenőrizzük a kettes beviteli mező értékét.
        /// Ha az érték számot tartalmaz akkor hiba üzenetet dob egy új ablakban, ha pedig helyes akkor beállítja az új nevet.
        /// </remarks>
        private void NevValtas2_Click(object sender, RoutedEventArgs e)
        {
            bool vaneszam = false;
            for (int i = 0; i < Bevitel2.Text.Length; i++)
            {
                if (!char.IsDigit(Bevitel2.Text[i]))
                {
                    vaneszam = false;
                }
                else
                {
                    vaneszam = true;
                    break;
                }
            }
            if (vaneszam)
            {
                HibaUzenet hiba = new HibaUzenet("A tulaj nevében nem lehet szám!");
                hiba.Show();
            }
            else
            {
                szamla2.tulaj = Bevitel2.Text;
                Szamla2Tul.Text = szamla2.tulaj;
            }
        }
    }
}
