using System;
using System.ComponentModel;

namespace ProyectoConjunto.Models
{
    public class Pasos : INotifyPropertyChanged
    {
        private int id;
        private int numPaso;
        private string descripcion;
        private int idReceta;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // 🔹 Constructor vacío
        public Pasos() { }

        // 🔹 Constructor con parámetros
        public Pasos(int id, int numPaso, string descripcion, int idReceta)
        {
            this.id = id;
            this.numPaso = numPaso;
            this.descripcion = descripcion;
            this.idReceta = idReceta;
        }

        // 🔹 Propiedades con notificación de cambio
        public int Id
        {
            get => id;
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }

        public int NumPaso
        {
            get => numPaso;
            set
            {
                if (numPaso != value)
                {
                    numPaso = value;
                    OnPropertyChanged(nameof(NumPaso));
                }
            }
        }

        public string Descripcion
        {
            get => descripcion;
            set
            {
                if (descripcion != value)
                {
                    descripcion = value;
                    OnPropertyChanged(nameof(Descripcion));
                }
            }
        }

        public int IdReceta
        {
            get => idReceta;
            set
            {
                if (idReceta != value)
                {
                    idReceta = value;
                    OnPropertyChanged(nameof(IdReceta));
                }
            }
        }
    }
}

