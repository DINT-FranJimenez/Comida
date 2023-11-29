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
        private string nombre;

        public string Nombre 
        {
            get { return this.nombre; }

            set 
            {
                this.nombre = value;
                this.NotifyPropertyChanged("Nombre");
            } 
        }

        private string imagen;
        public string Imagen 
        {
            get { return this.imagen; }
            set 
            {
                this.imagen = value;
                this.NotifyPropertyChanged("Imagen");
            } 
        }


        private string tipo;
        public string Tipo 
        {
            get { return this.tipo; }
            set
            {
                this.tipo = value;
                this.NotifyPropertyChanged("Tipo");
            }
        }

        private bool gluten;

        public bool Gluten 
        {
            get { return gluten; }
            set
            {
                this.gluten = value;
                this.NotifyPropertyChanged("Gluten");
            }
        }

        private bool soja;

        public bool Soja 
        {
            get { return this.soja; }
            set
            {
                this.soja = value;
                this.NotifyPropertyChanged("Soja");
            }
        }

        private bool leche;

        public bool Leche 
        {
            get { return this.leche; }
            set
            {
                this.leche = value;
                this.NotifyPropertyChanged("Leche");
            }
        }

        private bool sulfitos;

        public bool Sulfitos 
        {
            get { return this.sulfitos; }
            set
            {
                this.sulfitos = value;
                this.NotifyPropertyChanged("Sulfitos");
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

        public Plato(){}

        public event PropertyChangedEventHandler? PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static ObservableCollection<Plato> GetSamples(string rutaImagenes)
        {
            ObservableCollection<Plato> lista = new ObservableCollection<Plato>();

            ObservableCollection<Plato> observableCollection = new ObservableCollection<Plato>();
            observableCollection.Add(new Plato("Hamburguesa", Path.Combine(rutaImagenes, @"burguer.jpg"), "Americana", gluten: true, soja: false, leche: true, sulfitos: true));
            observableCollection.Add(new Plato("Dumplings", Path.Combine(rutaImagenes, @"dumplings.jpg"), "China", gluten: true, soja: true, leche: false, sulfitos: false));
            observableCollection.Add(new Plato("Tacos", Path.Combine(rutaImagenes, @"tacos.jpg"), "Mexicana", gluten: true, soja: false, leche: false, sulfitos: true));
            observableCollection.Add(new Plato("Cerdo agridulce", Path.Combine(rutaImagenes, @"cerdoagridulce.jpg"), "China", gluten: true, soja: true, leche: false, sulfitos: true));
            observableCollection.Add(new Plato("Hot dogs", Path.Combine(rutaImagenes, @"hotdog.jpg"), "Americana", gluten: true, soja: true, leche: true, sulfitos: true));
            observableCollection.Add(new Plato("Fajitas", Path.Combine(rutaImagenes, @"fajitas.jpg"), "Mexicana", gluten: true, soja: false, leche: false, sulfitos: true));
            return observableCollection;

        }
    }
}
