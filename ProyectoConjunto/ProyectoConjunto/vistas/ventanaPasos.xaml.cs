using ProyectoConjunto.models;
using ProyectoConjunto.Models;
using ProyectoConjunto.viewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProyectoConjunto
{
    /// <summary>
    /// Lógica de interacción para ventanaPasos.xaml
    /// </summary>
    /// 

    public partial class ventanaPasos : Window
    {

        public PasosViewModel viewModel;

        public ventanaPasos(Receta receta)
        {
            InitializeComponent();
            viewModel = new PasosViewModel();
            this.DataContext = viewModel;


            viewModel.RecetaSeleccionada = receta;
        }

        private void btn_siguiente_Click(object sender, RoutedEventArgs e)
        {
            viewModel.siguientePaso();
        }

        private void btn_anterior_Click(object sender, RoutedEventArgs e)
        {
            viewModel.anteriorPaso();
        }
    }
}
