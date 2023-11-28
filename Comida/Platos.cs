using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comida
{
    class Plato : INotifyPropertyChanged
    {
        public string Nombre 
        {
            get { return Nombre; }

            set 
            {
                Nombre = value;
                NotifyPropertyChanged("Nombre");
            } 
        }
        public string Imagen 
        {
            get { return Imagen; }
            set 
            { 
                Imagen = value;
                NotifyPropertyChanged("Imagen");
            } 
        }
        public string Tipo 
        {
            get { return Tipo; }
            set
            {
                Tipo = value;
                NotifyPropertyChanged("Tipo");
            }
        }

        public bool Gluten 
        {
            get { return Gluten; }
            set
            {
                Gluten = value;
                NotifyPropertyChanged("Gluten");
            }
        }

        public bool Soja 
        {
            get { return Soja; }
            set
            {
                Soja = value;
                NotifyPropertyChanged("Soja");
            }
        }

        public bool Leche 
        {
            get { return Leche; }
            set
            {
                Leche = value;
                NotifyPropertyChanged("Leche");
            }
        }
        public bool Sulfitos 
        {
            get { return Sulfitos; }
            set
            {
                Sulfitos = value;
                NotifyPropertyChanged("Sulfitos");
            }
        }

        public Plato(string nombre, string imagen, string tipo, bool gluten, bool soja, bool leche, bool sulfitos)
        {
            Nombre = nombre;
            Imagen = imagen;
            Tipo = tipo;
            Gluten = gluten;
            Soja = soja;
            Leche = leche;
            Sulfitos = sulfitos;
        }

        public Plato()
        {
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void NotifyPropertyChanged(String PropertyName)
        {
            this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        public static ObservableCollection<Plato> GetSamples(string rutaImagenes)
        {
            ObservableCollection<Plato> lista = new ObservableCollection<Plato>();

            lista.Add(new Plato("Hamburguesa", Path.Combine(rutaImagenes, @"burguer.jpg"), "Americana", true, false, true, true));
            lista.Add(new Plato("Dumplings", Path.Combine(rutaImagenes, @"dumplings.jpg"), "China", true, true, false, false));
            lista.Add(new Plato("Tacos", Path.Combine(rutaImagenes, @"tacos.jpg"), "Mexicana", true, false, false, true));
            lista.Add(new Plato("Cerdo agridulce", Path.Combine(rutaImagenes, @"cerdoagridulce.jpg"), "China", true, true, false, true));
            lista.Add(new Plato("Hot dogs", Path.Combine(rutaImagenes, @"hotdog.jpg"), "Americana", true, true, true, true));
            lista.Add(new Plato("Fajitas", Path.Combine(rutaImagenes, @"fajitas.jpg"), "Mexicana", true, false, false, true));

            return lista;
        }
    }
}
