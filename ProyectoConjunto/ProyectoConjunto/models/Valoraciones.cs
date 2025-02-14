using System;
using System.ComponentModel;

namespace ProyectoConjunto.models
{
    public class Valoraciones : INotifyPropertyChanged
    {
        private int id;
        private int puntuacion;
        private string comentario;
        private int idReceta;
        private int idUsuario;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Valoraciones() { }

        public Valoraciones(int id, int puntuacion, string comentario, int idReceta, int idUsuario)
        {
            this.id = id;
            this.puntuacion = puntuacion;
            this.comentario = comentario;
            this.idReceta = idReceta;
            this.idUsuario = idUsuario;
        }

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

        public int Puntuacion
        {
            get => puntuacion;
            set
            {
                if (puntuacion != value)
                {
                    puntuacion = value;
                    OnPropertyChanged(nameof(Puntuacion));
                }
            }
        }

        public string Comentario
        {
            get => comentario;
            set
            {
                if (comentario != value)
                {
                    comentario = value;
                    OnPropertyChanged(nameof(Comentario));
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

        public int IdUsuario
        {
            get => idUsuario;
            set
            {
                if (idUsuario != value)
                {
                    idUsuario = value;
                    OnPropertyChanged(nameof(IdUsuario));
                }
            }
        }
    }
}