﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
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

        private MainWindowVM vm = new MainWindowVM();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = vm;
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            xTextName.IsEnabled = true;
            xTextImage.IsEnabled = true;
            xCheckBoxLeche.IsEnabled = true;
            xCheckBoxSoja.IsEnabled = true;
            xCheckBoxSulfitos.IsEnabled = true;
            xCheckBoxGluten.IsEnabled = true;
            xButtonDeselecciona.IsEnabled = true;
            xComboBoxTipo.IsEnabled = true;

            if (e.AddedItems.Count > 0)
            {
                // Obtén el elemento seleccionado 
                vm.Plato = (Plato)e.AddedItems[0];                  
            }
        }

        private void Deseleccionar_Click(object sender, RoutedEventArgs e)
        {
            
            //Deseleccionamos el elemento del lixtbox
            xListBoxPlatos.SelectedItem = null;

            //Limpio los Text Box
            xTextName.Text= "";
            xTextImage.Text= "";
            xComboBoxTipo.Text = "";

            //Deselecciono botones
            xCheckBoxLeche.IsChecked = false;
            xCheckBoxSoja.IsChecked = false;
            xCheckBoxSulfitos.IsChecked = false;
            xCheckBoxGluten.IsChecked = false;

            //Deshabilito los elementos
            xTextName.IsEnabled = false;
            xTextImage.IsEnabled = false;
            xCheckBoxLeche.IsEnabled = false;
            xCheckBoxSoja.IsEnabled = false;
            xCheckBoxSulfitos.IsEnabled = false;
            xCheckBoxGluten.IsEnabled = false;
            xComboBoxTipo.IsEnabled = false;

        }

    }
}
