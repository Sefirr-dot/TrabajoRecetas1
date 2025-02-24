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
using System.IO;

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

                Receta receta = (Receta) DataGridRecetas.SelectedItem;

                viewModel.RecetaSeleccionada = receta;

                viewModel.cargarIngredientes(receta);

                viewModel.cargarPasos(receta);
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

        private void delete(object sender, RoutedEventArgs e)
        {
            
            if (viewModel.RecetaSeleccionada != null)
            {

                Receta receta = (Receta)DataGridRecetas.SelectedItem;

                if (receta != null)
                {

                    MessageBoxResult result = MessageBox.Show(
                        "¿Estás seguro de que deseas eliminar esta receta?",
                        "Confirmación",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Warning
                    );

                    // Si el usuario presiona "Sí", procedemos con la eliminación
                    if (result == MessageBoxResult.Yes)
                    {

                        Repositorio.EliminarReceta(receta);                       
                        viewModel.listRecetas.Remove(receta);
                        MessageBox.Show("Elemento eliminado con éxito.", "Eliminado", MessageBoxButton.OK, MessageBoxImage.Information);
                        viewModel.RecetaSeleccionada = new Receta();
                        viewModel.listIngredientesReceta.Clear();
                        viewModel.listPasosReceta.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Debes de seleccionar primero la receta que quieres borrar");
                }
            }
        }
    }
}

