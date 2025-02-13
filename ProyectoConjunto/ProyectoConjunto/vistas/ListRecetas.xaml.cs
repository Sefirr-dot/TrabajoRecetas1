using ProyectoConjunto.models;
using ProyectoConjunto.Models;
using ProyectoConjunto.repositorio;
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
using ProyectoConjunto.singleton;

namespace ProyectoConjunto.vistas
{
    /// <summary>
    /// Lógica de interacción para Main.xaml
    /// </summary>
    public partial class ListRecetas : Window

    {

        public ListaRecetasViewModel viewModel;

        public ListRecetas()
        {
            InitializeComponent();
            
            viewModel = new ListaRecetasViewModel();        
            viewModel.NombreUser = UsuarioSingleton.Nombre;
            this.DataContext = viewModel;

        }

        private void DataGridRecetas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if(DataGridRecetas.SelectedItem != null)
            {
                viewModel.RecetaSeleccionada = (Receta) DataGridRecetas.SelectedItem;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginPrincipal pag = new LoginPrincipal();
            pag.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NewReceta receta = new NewReceta();
            receta.Show();
            this.Close();
        }

        private void VerPasos_Click(object sender, RoutedEventArgs e)
        {
            if (viewModel.RecetaSeleccionada != null)
            {
                ventanaPasos ventanaPasos = new ventanaPasos(viewModel.RecetaSeleccionada);
                ventanaPasos.Show();
            }

        }
    }
}
