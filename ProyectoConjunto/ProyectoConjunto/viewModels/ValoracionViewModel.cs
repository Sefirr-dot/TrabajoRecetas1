using ProyectoConjunto.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoConjunto.viewModels
{
    public class ValoracionViewModel : INotifyPropertyChanged
    {

        private Receta recetaSeleccionada;

        public ValoracionViewModel()
        {

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

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void actualizarRecetaActual(Receta receta)
        {
            recetaSeleccionada = receta;
            OnPropertyChanged(nameof(RecetaSeleccionada));
        }



    }
}
