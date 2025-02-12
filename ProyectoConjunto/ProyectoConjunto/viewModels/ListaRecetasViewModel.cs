using ProyectoConjunto.models;
using ProyectoConjunto.repositorio;
using ProyectoConjunto.vistas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoConjunto.viewModels
{
    public class ListaRecetasViewModel : INotifyPropertyChanged
    {

        private Receta recetaSeleccionada;
        private ObservableCollection<Receta> listRecetas;
        private Repositorio repositorio;

        public ListaRecetasViewModel()
        {
            recetaSeleccionada = new Receta();
            listRecetas = new ObservableCollection<Receta>();
            repositorio = new Repositorio();
            cargarRecetas();
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

        public ObservableCollection<Receta> ListRecetas
        {
            get => listRecetas;
            set
            {
                listRecetas = value;
                OnPropertyChanged(nameof(ListRecetas));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void cargarRecetas()
        {
            listRecetas = repositorio.CargarRecetasDesdeBaseDeDatos();
            OnPropertyChanged(nameof(ListRecetas));
        }

    }
}
