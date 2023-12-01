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

        private string pathImage = "C:\\Users\\alumno\\source\\repos\\Comida\\Comida\\Imagenes\\";

        private MainWindowVM vm;
        private Plato selectedPlato;


        public MainWindow()
        {
            InitializeComponent();

            vm = new MainWindowVM(Plato.GetSamples(pathImage));

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
                selectedPlato = (Plato)e.AddedItems[0];
                // Asigna el nombre del elemento seleccionado al TextBox
                xTextName.Text = selectedPlato.Nombre;
                xTextImage.Text = selectedPlato.Imagen;
                xComboBoxTipo.Text = selectedPlato.Tipo;

                if (selectedPlato.Leche) xCheckBoxLeche.IsChecked = true;
                else xCheckBoxLeche.IsChecked = false;

                if (selectedPlato.Soja) xCheckBoxSoja.IsChecked = true;
                else xCheckBoxSoja.IsChecked = false;

                if (selectedPlato.Sulfitos) xCheckBoxSulfitos.IsChecked = true;
                else xCheckBoxSulfitos.IsChecked = false;

                if (selectedPlato.Gluten) xCheckBoxGluten.IsChecked = true;
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
                        selectedPlato.Soja = true;
                        break;
                    case "Sulfitos":
                        selectedPlato.Sulfitos = true;
                        break;
                    case "Leche":
                        selectedPlato.Leche = true;
                        break;
                    case "Gluten":
                        selectedPlato.Gluten = true;
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
                        selectedPlato.Soja = false;
                        break;
                    case "Sulfitos":
                        selectedPlato.Sulfitos = false;
                        break;
                    case "Leche":
                        selectedPlato.Leche =false;
                        break;
                    case "Gluten":
                        selectedPlato.Gluten = false;
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
                    selectedPlato.Tipo = "Americana";
                    break;
                case "China":
                    selectedPlato.Tipo = "China";
                    break;
                case "Mexicana":
                    selectedPlato.Tipo = "Mexicana";
                    break;
            }
        }
    }
}
