using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comida
{
    internal class MainWindowVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private ObservableCollection<Plato> platosSelecionados;


        public ObservableCollection<Plato> PlatosSeleccionados
        {
            get { return platosSelecionados; }
            set 
            {
                platosSelecionados = value;
                NotifyPropertyChanged("PlatosSelecionados");
            }
        }

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainWindowVM(ObservableCollection<Plato> platos) 
        {
            this.PlatosSeleccionados = platos;
        }
    }
}
