using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace ProyectoConjunto.models
{
    public class Receta : INotifyPropertyChanged
    {
        private int id;
        private string nombre;
        private string dificultad;
        private string duracion;
        private string descripcion;
        private int idUsuario;
        private string imagen;
        private double mediaValoraciones;

        public BitmapImage Imagen64 { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public Receta()
        {
            this.id = 0;
            this.nombre = "";
            this.dificultad = "";
            this.duracion = "";
            this.descripcion = "";
            this.idUsuario = 0;
            this.imagen = "/images/noimage.jpg";
            this.mediaValoraciones = 0.0;
            this.Imagen64 = (BitmapImage?)ConvertBase64ToImage(imagen);
        }
        private ImageSource ConvertBase64ToImage(string imagen)
        {
            if (string.IsNullOrEmpty(imagen))
                return null;

            try
            {
                byte[] imageBytes = Convert.FromBase64String(imagen);
                using (MemoryStream memoryStream = new MemoryStream(imageBytes))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.StreamSource = memoryStream;
                    bitmapImage.EndInit();
                    return bitmapImage;
                }
            }
            catch
            {
                return null; // Devuelve null si hay un error en la conversión
            }
        }

        public Receta(int id, string nombre, string dificultad, string duracion, string descripcion, int idUsuario, string imagen, double mediaValoraciones)
        {
            this.id = id;
            this.nombre = nombre;
            this.dificultad = dificultad;
            this.duracion = duracion;
            this.descripcion = descripcion;
            this.idUsuario = idUsuario;
            this.imagen = imagen;
            this.mediaValoraciones = mediaValoraciones;
            this.Imagen64 = (BitmapImage?)ConvertBase64ToImage(imagen);
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

        public string Duracion
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

        public double MediaValoraciones
        {
            get => mediaValoraciones;
            set { mediaValoraciones = value; OnPropertyChanged(nameof(MediaValoraciones)); }
        }
    }
}
