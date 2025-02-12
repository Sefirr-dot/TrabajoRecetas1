using System;
using System.ComponentModel;

namespace ProyectoConjunto.models
{
    public class Receta : INotifyPropertyChanged
    {
        private int id;
        private string nombre;
        private string dificultad;
        private int duracion;
        private string descripcion;
        private int idUsuario;
        private string imagen;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Constructor vacío
        public Receta()
        {
            this.id = 0;
            this.nombre = string.Empty;
            this.dificultad = string.Empty;
            this.duracion = 0;
            this.descripcion = string.Empty;
            this.idUsuario = 0;
            this.imagen = string.Empty;
        }

        // Constructor con parámetros
        public Receta(int id, string nombre, string dificultad, int duracion, string descripcion, int idUsuario, string imagen)
        {
            this.id = id;
            this.nombre = nombre;
            this.dificultad = dificultad;
            this.duracion = duracion;
            this.descripcion = descripcion;
            this.idUsuario = idUsuario;
            this.imagen = imagen;
        }

        public int Id
        {
            get => id;
            set { id = value; OnPropertyChanged(nameof(Id)); }
        }
        public string Nombre
        {
            get => nombre;
            set { nombre = value; OnPropertyChanged(nameof(Nombre)); }
        }
        public string Dificultad
        {
            get => dificultad;
            set { dificultad = value; OnPropertyChanged(nameof(Dificultad)); }
        }
        public int Duracion
        {
            get => duracion;
            set { duracion = value; OnPropertyChanged(nameof(Duracion)); }
        }
        public string Descripcion
        {
            get => descripcion;
            set { descripcion = value; OnPropertyChanged(nameof(Descripcion)); }
        }
        public int IdUsuario
        {
            get => idUsuario;
            set { idUsuario = value; OnPropertyChanged(nameof(IdUsuario)); }
        }

        public string Imagen
        {
            get => imagen;
            set { imagen = value; OnPropertyChanged(nameof(Imagen)); }
        }
    }
}
