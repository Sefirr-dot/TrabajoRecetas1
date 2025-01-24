using ProyectoConjunto.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoConjunto.viewModels
{
    public class RecetaViewModel : INotifyPropertyChanged
    {

        private int id;
        private string nombre;
        private string dificultad;
        private int duracion;
        private string descripcion;
        private int idUsuario;
        private ObservableCollection<Ingredientes> listIngredientes;
        private ObservableCollection<Pasos> listPasos;
        private ObservableCollection<Valoraciones> listValoraciones;

        public RecetaViewModel(int id, string nombre, string dificultad, int duracion, string descripcion, int idUsuario, ObservableCollection<Ingredientes> listIngredientes, ObservableCollection<Pasos> listPasos, ObservableCollection<Valoraciones> listValoraciones)
        {
            this.id = id;
            this.nombre = nombre;
            this.dificultad = dificultad;
            this.duracion = duracion;
            this.descripcion = descripcion;
            this.idUsuario = idUsuario;
            this.listIngredientes = listIngredientes;
            this.listPasos = listPasos;
            this.listValoraciones = listValoraciones;
        }

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Id"));
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Nombre"));
            }
        }

        public string Dificultad
        {
            get
            {
                return dificultad;
            }
            set
            {
                dificultad = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Dificultad"));
            }
        }

        public int Duracion
        {
            get
            {
                return duracion;
            }
            set
            {
                duracion = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Duracion"));
            }
        }

        public string Descripcion
        {
            get
            {
                return descripcion;
            }
            set
            {
                nombre = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Nombre"));
            }
        }

        public int IdUsuario
        {
            get
            {
                return idUsuario;
            }
            set
            {
                idUsuario = value;
                PropertyChanged(this, new PropertyChangedEventArgs("IdUsuario"));
            }
        }

        public ObservableCollection<Ingredientes> ListIngredientes
        {
            get
            {
                return listIngredientes;
            }
            set
            {
                ListIngredientes = value;
                PropertyChanged(this, new PropertyChangedEventArgs("listIngredientes"));
            }
        }

        public ObservableCollection<Pasos> ListPasos
        {
            get
            {
                return listPasos;
            }
            set
            {
                ListPasos = value;
                PropertyChanged(this, new PropertyChangedEventArgs("listPasos"));
            }
        }

        public ObservableCollection<Valoraciones> ListValoraciones
        {
            get
            {
                return listValoraciones;
            }
            set
            {
                ListValoraciones = value;
                PropertyChanged(this, new PropertyChangedEventArgs("listValoraciones"));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
