using ProyectoConjunto.models;
using ProyectoConjunto.repositorio;
using ProyectoConjunto.singleton;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProyectoConjunto.viewModels
{
    public class ValoracionViewModel : INotifyPropertyChanged
    {

        private Receta recetaSeleccionada;
        private int valoracion;
        private Valoraciones valoracionReceta;

        public ValoracionViewModel()
        {
            valoracion = 0;
            valoracionReceta = new Valoraciones();
            recetaSeleccionada = new Receta();

            

        }

        public Receta RecetaSeleccionada
        {
            get => recetaSeleccionada;
            set
            {
                recetaSeleccionada = value;
                OnPropertyChanged(nameof(RecetaSeleccionada));
            }
        }

        public Valoraciones ValoracionReceta
        {
            get => valoracionReceta;
            set
            {
                valoracionReceta = value;
                OnPropertyChanged(nameof(ValoracionReceta));
            }
        }

        public int Valoracion
        {
            get => valoracion;
            set
            {
                valoracion = value;
                OnPropertyChanged(nameof(Valoracion));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void actualizarRecetaActual(Receta receta)
        {
            RecetaSeleccionada = receta;
            OnPropertyChanged(nameof(RecetaSeleccionada));

            MessageBox.Show(RecetaSeleccionada.ToString());
        }

        public void guardarValoracion()
        {
            Repositorio.guardarValoracion(valoracionReceta);
        }

    }
}
