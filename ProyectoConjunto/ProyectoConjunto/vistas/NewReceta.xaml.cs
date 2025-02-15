using ProyectoConjunto.Models;
using ProyectoConjunto.singleton;
using ProyectoConjunto.viewModels;
using System;
using System.Collections.Generic;
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

namespace ProyectoConjunto.vistas
{
    /// <summary>
    /// Lógica de interacción para NewReceta.xaml
    /// </summary>
    public partial class NewReceta : Window
    {

        private RecetaViewModel recetaViewModel;


        public NewReceta()
        {
            InitializeComponent();
            recetaViewModel = new RecetaViewModel();
            recetaViewModel.NombreUser = UsuarioSingleton.Nombre;
            this.DataContext = recetaViewModel;

            recetaViewModel.PasosALista.NumPaso = recetaViewModel.ListaPasos.Count() + 1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ListRecetas page = new ListRecetas();
            page.Show();

            this.Close();
        }

        private void seleccionar_imagen_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is RecetaViewModel viewModel)
            {
                viewModel.SeleccionarImagen();
            }
        }

        private void btn_guardar_Click(object sender, RoutedEventArgs e)
        {
            recetaViewModel.pillarDatos();
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtDificultad.Text = "";        
            txtDuracion.Text = "";
            recetaViewModel.EliminarPasos();
            ListaIngredientes.SelectedItems.Clear();
            recetaViewModel.PasosALista.NumPaso = recetaViewModel.ListaPasos.Count() + 1;

        }

        private void add_paso_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is RecetaViewModel recetaViewModel)
            {
                recetaViewModel.AgregarPaso();
                recetaViewModel.PasosALista.NumPaso = recetaViewModel.ListaPasos.Count() + 1;
            }
        }

        private void delete(object sender, RoutedEventArgs e)
        {
            if (DataContext is RecetaViewModel recetaViewModel)
            {

                Pasos p = (Pasos)tvPasos.SelectedItem;

                if (p != null)
                {

                    MessageBoxResult result = MessageBox.Show(
                        "¿Estás seguro de que deseas eliminar este elemento?",
                        "Confirmación",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Warning
                    );

                    // Si el usuario presiona "Sí", procedemos con la eliminación
                    if (result == MessageBoxResult.Yes)
                    {

                        recetaViewModel.ListaPasos.Remove(p);

                        for (int i = 0; i < recetaViewModel.ListaPasos.Count(); i++)
                        {

                            recetaViewModel.ListaPasos[i].NumPaso = i + 1;

                            recetaViewModel.PasosALista.NumPaso = recetaViewModel.ListaPasos.Count() + 1;

                        }

                        MessageBox.Show("Elemento eliminado con éxito.", "Eliminado", MessageBoxButton.OK, MessageBoxImage.Information);

                    }



                }
                else
                {

                    MessageBox.Show("Debes de seleccionar primero el paso que quieres borrar");

                }



            }
        }
        private void IngredientesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataContext is RecetaViewModel viewModel)
            {
                viewModel.ActualizarIngredientesSeleccionados(ListaIngredientes.SelectedItems);
            }
        }
    }
}
