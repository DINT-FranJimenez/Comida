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

namespace Comida
{
   
    public partial class MainWindow : Window
    {

        private string pathImage = "/Comida/FotosPlatos/";

        private MainWindowVM vm;

        private Plato platos;

        public MainWindow()
        {
            InitializeComponent();

            vm = new MainWindowVM(Plato.GetSamples(pathImage));
        }
    }
}
