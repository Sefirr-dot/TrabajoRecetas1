﻿using ProyectoConjunto.models;
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
        private Repositorio repositorio;

        public ValoracionViewModel()
        {
            valoracion = 0;
            valoracionReceta = new Valoraciones();
            recetaSeleccionada = new Receta();
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
            double mediaActualizada = repositorio.ObtenerMediaValoracionesPorReceta(recetaSeleccionada.Id);

            // Redondear el valor a 2 decimales
            mediaActualizada = Math.Round(mediaActualizada, 2);

            // Actualizar la propiedad en la receta seleccionada
            recetaSeleccionada.MediaValoraciones = mediaActualizada;

            OnPropertyChanged(nameof(RecetaSeleccionada));
        }


        public void guardarValoracion()
        {

            Repositorio.guardarValoracion(valoracionReceta);

            actualizarRecetaActual(recetaSeleccionada);




        }

    }
}
