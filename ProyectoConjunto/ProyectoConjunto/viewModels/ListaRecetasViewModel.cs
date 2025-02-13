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
using System.Windows;

namespace ProyectoConjunto.viewModels
{
    public class ListaRecetasViewModel : INotifyPropertyChanged
    {

        private Receta recetaSeleccionada;
        public ObservableCollection<Receta> listRecetas {  get; set; }
        private int id;
        private Repositorio repositorio;
        private string nombreUser;
        public ListaRecetasViewModel()
        {
            recetaSeleccionada = new Receta();
            
            repositorio = new Repositorio();
            listRecetas = repositorio.CargarRecetasDesdeBaseDeDatos();
            
        }

        public string NombreUser
        {
            get => nombreUser;
            set
            {
                nombreUser = value;
                OnPropertyChanged(nameof(NombreUser));
            }
        }
        public int Id
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
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

        private void cargarRecetas()
        {
            listRecetas = repositorio.CargarRecetasDesdeBaseDeDatos();
            OnPropertyChanged(nameof(ListRecetas));
        }

    }
}
