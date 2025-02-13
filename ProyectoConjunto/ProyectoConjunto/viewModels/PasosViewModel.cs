using ProyectoConjunto.models;
using ProyectoConjunto.Models;
using ProyectoConjunto.repositorio;
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
    public class PasosViewModel : INotifyPropertyChanged
    {
        
        private Repositorio repositorio;
        private Receta recetaSeleccionada;
        private ObservableCollection<Pasos> pasosReceta;
        private int posicionPaso = 0;
        private int totalPasos;
        private int avanceProgressBar = 0;
        private Pasos pasoActual;

        public PasosViewModel()
        {
            repositorio = new Repositorio();
            
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

        public int PosicionPaso
        {
            get => posicionPaso;
            set
            {
                posicionPaso = value;
                OnPropertyChanged(nameof(PosicionPaso));
            }
        }

        public int TotalPasos
        {
            get => totalPasos;
            set
            {
                totalPasos = value;
                OnPropertyChanged(nameof(TotalPasos));
            }
        }

        public int AvanceProgressBar
        {
            get => avanceProgressBar;
            set
            {
                avanceProgressBar = value;
                OnPropertyChanged(nameof(AvanceProgressBar));
            }
        }

        public Pasos PasoActual
        {
            get => pasoActual;
            set
            {
                pasoActual = value;
                OnPropertyChanged(nameof(PasoActual));
            }
        }

        public ObservableCollection<Pasos> PasosReceta
        {
            get => pasosReceta;
            set
            {
                pasosReceta = value;
                OnPropertyChanged(nameof(PasosReceta));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void siguientePaso()
        {

            if((posicionPaso + 1) == pasosReceta.Count)
            {

                ventanaValoracion ven = new ventanaValoracion(recetaSeleccionada);
                ven.Show();
               

            } else
            {
                if ((posicionPaso + 1) <= pasosReceta.Count - 1)
                {
                    posicionPaso += 1;

                    pasoActual = pasosReceta[posicionPaso];

                    avanceProgressBar += 1;

                    OnPropertyChanged(nameof(PasoActual));

                    OnPropertyChanged(nameof(PosicionPaso));

                    OnPropertyChanged(nameof(AvanceProgressBar));


                }
                else
                {
                    MessageBox.Show("No ha más pasos para mostrar");
                }
            }


        }

        public void anteriorPaso()
        {

            if ((posicionPaso - 1) >= 0)
            {
                posicionPaso -= 1;

                avanceProgressBar -= 1;

                pasoActual = pasosReceta[posicionPaso];

                OnPropertyChanged(nameof(PasoActual));

                OnPropertyChanged(nameof(PosicionPaso));

                OnPropertyChanged(nameof(AvanceProgressBar));


            }
            else
            {
                MessageBox.Show("No ha más pasos para mostrar");
            }

        }

        public void cargarPasos(int id)
        {
            pasosReceta = repositorio.CargarPasosDeReceta(id);

            posicionPaso = 0;

            totalPasos = pasosReceta.Count - 1;

            pasoActual = pasosReceta[posicionPaso];

            OnPropertyChanged(nameof(PasoActual));

            OnPropertyChanged(nameof(TotalPasos));

            OnPropertyChanged(nameof(PosicionPaso));

            OnPropertyChanged(nameof(AvanceProgressBar));


        }
    }
}
