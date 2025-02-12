using ProyectoConjunto.models;
using ProyectoConjunto.Models;
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

        private Receta recetaSeleccionada;
        private ObservableCollection<Pasos> pasosReceta;
        private int posicionPaso = 0;
        private int totalPasos;
        private int avanceProgressBar = 0;
        private Pasos pasoActual;

        public PasosViewModel()
        {
            recetaSeleccionada = new Receta();
            pasosReceta = new ObservableCollection<Pasos>
            {
                new Pasos(1, 1, "Lava bien todas las verduras bajo el chorro de agua fría y sécalas con papel de cocina antes de cortarlas en trozos pequeños.", 101),
                new Pasos(2, 2, "En una sartén grande, añade una cucharada de aceite de oliva y caliéntalo a fuego medio hasta que empiece a brillar.", 101),
                new Pasos(3, 3, "Agrega la cebolla picada y sofríe durante unos 5 minutos hasta que esté transparente, removiendo constantemente.", 101),
                new Pasos(4, 4, "Incorpora los tomates y el ajo picado, y cocina por otros 3 minutos hasta que los tomates comiencen a soltar su jugo.", 101),
                new Pasos(5, 5, "Añade las especias y la sal, remueve bien para distribuir los sabores de manera uniforme en la preparación.", 101),
                new Pasos(6, 6, "Reduce el fuego y deja cocinar a fuego lento durante 15 minutos, removiendo ocasionalmente para evitar que se pegue.", 101),
                new Pasos(7, 7, "Una vez listo, retira del fuego y deja reposar por unos minutos antes de servir acompañado de arroz o pan tostado.", 101)
            };

            pasoActual = pasosReceta[posicionPaso];
            totalPasos = pasosReceta.Count - 1;
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

                ventanaValoracion ven = new ventanaValoracion();
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
    }
}
