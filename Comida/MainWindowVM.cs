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

        private ObservableCollection<Plato> platos;

        public ObservableCollection<Plato> Platos 
        {
            get { return platos; }
            set 
            { 
                Platos  = value;
                NotifyPropertyChanged("PLatos");
            }
        }

        public void NotifyPropertyChanged(String PropertyName)
        {
            this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        public MainWindowVM(ObservableCollection<Plato> platos) 
        {
            this.Platos = platos;
        }
    }
}
