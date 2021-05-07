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
using System.Windows.Shapes;

namespace TothRegina_beadandó
{
    /// <summary>
    /// Interaction logic for HibaUzenet.xaml
    /// </summary>
    public partial class HibaUzenet : Window
    {
        /// <summary>
        /// A hibaüzenet ablakhoz tartozó konstruktor, amely beállítja a kapott üzenetet.
        /// </summary>
        /// <param name="uzenet"></param>
        public HibaUzenet(string uzenet)
        {
            InitializeComponent();
            Uzenet.Text = uzenet;
        }
    }
}
