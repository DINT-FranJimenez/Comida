using System;
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

            if (e.AddedItems.Count > 0) {

                // Obtén el elemento seleccionado 
                vm.Plato = (Plato)e.AddedItems[0];
                // Asigna el nombre del elemento seleccionado al TextBox
                xTextName.Text = vm.Plato.Nombre;
                xTextImage.Text = vm.Plato.Imagen;
                xComboBoxTipo.Text = vm.Plato.Tipo;

                if (vm.Plato.Leche) xCheckBoxLeche.IsChecked = true;
                else xCheckBoxLeche.IsChecked = false;

                if (vm.Plato.Soja) xCheckBoxSoja.IsChecked = true;
                else xCheckBoxSoja.IsChecked = false;

                if (vm.Plato.Sulfitos) xCheckBoxSulfitos.IsChecked = true;
                else xCheckBoxSulfitos.IsChecked = false;

                if (vm.Plato.Gluten) xCheckBoxGluten.IsChecked = true;
                else xCheckBoxGluten.IsChecked = false;
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

        private void Poner_Checked(object sender, RoutedEventArgs e)
        {
            
            CheckBox checkBox =  sender as CheckBox;

            if (xListBoxPlatos.SelectedItem != null)
            {
                switch (checkBox.Content.ToString())
                {
                    case "Soja":
                        vm.Plato.Soja = true;
                        break;
                    case "Sulfitos":
                        vm.Plato.Sulfitos = true;
                        break;
                    case "Leche":
                        vm.Plato.Leche = true;
                        break;
                    case "Gluten":
                        vm.Plato.Gluten = true;
                        break;
                }
            }
        }

        private void Quitar_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;

            if (xListBoxPlatos.SelectedItem != null)
            {
                switch (checkBox.Content.ToString())
                {
                    case "Soja":
                        vm.Plato.Soja = false;
                        break;
                    case "Sulfitos":
                        vm.Plato.Sulfitos = false;
                        break;
                    case "Leche":
                        vm.Plato.Leche =false;
                        break;
                    case "Gluten":
                        vm.Plato.Gluten = false;
                        break;
                }
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;

            string selectedItemContent = (comboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            switch (selectedItemContent)
            {
                case "Americana":
                    vm.Plato.Tipo = "Americana";
                    break;
                case "China":
                    vm.Plato.Tipo = "China";
                    break;
                case "Mexicana":
                    vm.Plato.Tipo = "Mexicana";
                    break;
            }
        }
    }
}
